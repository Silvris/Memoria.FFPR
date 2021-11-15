using Last.Management;
using System;
using Il2CppSystem.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Memoria.FFPR.Core;

namespace Memoria.FFPR.IL2CPP
{
    public sealed class ResourceCreator : MonoBehaviour
    {
        public static ResourceManager resourceManager { get; private set; }
        public static string ImportDirectory { get; set; }
        public static Dictionary<String, Dictionary<String, String>> OurFiles { get; set; }
        private bool isDisabled = false;
        public ResourceCreator(IntPtr ptr) : base(ptr)
        {
        }
        public ResourceCreator()
        {

        }
        public void Awake()
        {
            try
            {
                OurFiles = new Dictionary<string, Dictionary<string, string>>(); // set to a instance to not crash when disabled
                ImportDirectory = ModComponent.Instance.Config.Assets.ImportDirectory;
                if (ModComponent.Instance.Config.Assets.ExportDirectory != String.Empty)
                {
                    isDisabled = true;//disable as to not conflict with export
                }
            }
            catch(Exception ex)
            {
                ModComponent.Log.LogError($"[ResourceCreator].ctor:{ex}");
                isDisabled = true;
            }
        }

        public void Update()
        {
            if(resourceManager is null)
            {
                resourceManager = ResourceManager.Instance;
                if (resourceManager is null)
                    return;
            }
            else
            {
                if (!isDisabled)
                {

                    if (ImportDirectory != String.Empty || ImportDirectory != null)
                    {
                        AddFiles();
                        isDisabled = true;
                    }
                    else
                    {
                        isDisabled = true;
                    }
                    //break;
                }
            }

        }
        public static UnityEngine.Object LoadAsset(string fullPath, string ext)
        {
            switch (ext)
            {
                case ".csv":
                case ".txt":
                case ".json":
                    TextAsset asset = new TextAsset(File.ReadAllText(fullPath));
                    return asset;
                case ".png":
                    //check for .spriteData, with we define asset as Sprite, without we just load T2D itself
                    Texture2D tex = TextureHelper.ReadTextureFromFile(fullPath);
                    if (File.Exists(Path.ChangeExtension(fullPath, ".spriteData")))
                    {
                        SpriteData sd = new SpriteData(File.ReadAllLines(Path.ChangeExtension(fullPath, ".spriteData")), Path.GetFileNameWithoutExtension(fullPath));
                        Sprite spr = Sprite.Create(
                            tex,
                            sd.hasRect ? sd.rect : new Rect(0, 0, tex.width, tex.height),
                            sd.hasPivot ? sd.pivot : new Vector2(0.5f, 0.5f),
                            sd.hasPPU ? sd.pixelsPerUnit : 1f,
                            0,
                            SpriteMeshType.Tight,
                            sd.hasBorder ? sd.border : new Vector4(0, 0, 0, 0)
                            );
                        tex.wrapMode = sd.hasWrap ? sd.wrapMode : TextureWrapMode.Clamp;
                        return spr;
                    }
                    else
                    {
                        return tex;
                    }
                default:
                    return null;
            }
        }
        public bool ImportableFile(string path)
        {
            switch (Path.GetExtension(path))
            {
                case ".png":
                case ".csv":
                case ".json":
                case ".txt":
                    return true;
                default:
                    return false;
            }
        }
        public void AddFiles()
        {
            String[] groups = Directory.GetDirectories(ImportDirectory + "\\CustomFiles");
            List<string> keys = new List<string>();
            int iterator = 0;
            foreach(String group in groups)
            {
                ModComponent.Log.LogInfo(group + "/keys.json");
                if(File.Exists(group + "/keys.json"))
                {
                    keys.Add(File.ReadAllText(group + "/keys.json"));
                }
            }
            String assetsPathtxt = "{\"keys\": [ ";
            foreach (String group in groups)
            {
                if (iterator != 0) assetsPathtxt += ",";
                assetsPathtxt += $"\"{Path.GetFileName(group)}\"";
                iterator++;
            }
            assetsPathtxt += "], \"values\": [";
            iterator = 0;
            foreach (String kvd in keys)
            {
                if (iterator != 0) assetsPathtxt += ",";
                assetsPathtxt += $"\"{kvd.Replace("\n",String.Empty).Replace("\t",String.Empty).Replace("\r",String.Empty).Replace("\"","\\\"")}\"";
                iterator++;
            }
            assetsPathtxt += "]}";
            ModComponent.Log.LogInfo(assetsPathtxt);
            OurFiles = AssetPathUtilty.Parse(assetsPathtxt);
            if(OurFiles != null)
            {
                //kinda assuming it'll return null if the data is wrong
                foreach (KeyValuePair<string, Dictionary<string,string>> group in OurFiles)
                {
                    foreach (KeyValuePair<string, string> kvp in group.Value)
                    {
                        var fileGrab = Directory.GetFiles(ImportDirectory + $"\\CustomFiles\\{group.key}", $"{kvp.value}.*");
                        List<string> files = new List<string>();
                        foreach (string file in fileGrab)
                        {
                            if (ImportableFile(file))
                            {
                                files.Add(file);
                            }
                        }
                        if(files.Count > 0)
                        {
                            //at least one file exists, we're gonna just use the first one as to force unique keys
                            string file = files[0];
                            string ext = Path.GetExtension(file);
                            if(ext != String.Empty)
                            {
                                UnityEngine.Object asset = LoadAsset(file, ext);
                                if(asset != null)
                                {
                                    resourceManager.completeAssetDic.Add(kvp.value, asset);
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
