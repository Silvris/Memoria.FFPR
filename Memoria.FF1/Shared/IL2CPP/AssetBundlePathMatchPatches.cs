using HarmonyLib;
using Il2CppSystem.Asset;
using Last.Management;
using Memoria.FFPR.IL2CPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Memoria.FFPR.IL2CPP
{
    /*
    [HarmonyPatch(typeof(AssetBundlePathMatch), nameof(AssetBundlePathMatch.GetPath))]
    public sealed class AssetBundlePathMatch_GetPath : Il2CppSystem.Object
    {
        public AssetBundlePathMatch_GetPath(IntPtr ptr) : base(ptr)
        {
        }
        [HarmonyPrefix]
        public static bool Prefix(string groupName, string assetKey, ref string __result)
        {
            //ModComponent.Log.LogInfo($"GetAssetData Group:{groupName} Asset:{assetKey}");
            if (ResourceCreator.OurFiles.ContainsKey(groupName))
            {
                if (ResourceCreator.OurFiles[groupName].ContainsKey(assetKey))
                {
                    __result = ResourceCreator.OurFiles[groupName][assetKey];
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
    [HarmonyPatch(typeof(AssetBundlePathMatch), nameof(AssetBundlePathMatch.IsGroupKey))]
    public sealed class AssetBundlePathMatch_IsGroupKey : Il2CppSystem.Object
    {
        public AssetBundlePathMatch_IsGroupKey(IntPtr ptr) : base(ptr)
        {
        }
        public static bool Prefix(string groupName, ref bool __result)
        {
            //ModComponent.Log.LogInfo(assetGroup);
            if (ResourceCreator.OurFiles.ContainsKey(groupName))
            {
                __result = true;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    [HarmonyPatch(typeof(AssetBundlePathMatch), nameof(AssetBundlePathMatch.GetGroupData))]
    public sealed class AssetBundlePathMatch_GetGroupData : Il2CppSystem.Object
    {
        public AssetBundlePathMatch_GetGroupData(IntPtr ptr) : base(ptr)
        {
        }
        public static bool Prefix(string groupName, ref Il2CppSystem.Collections.Generic.Dictionary<string,string> __result)
        {
            //ModComponent.Log.LogInfo(assetGroup);
            if (ResourceCreator.OurFiles.ContainsKey(groupName))
            {
                __result = ResourceCreator.OurFiles[groupName];
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    [HarmonyPatch(typeof(AssetBundlePathMatch), nameof(AssetBundlePathMatch.GetAssetKeys))]
    public sealed class AssetBundlePathMatch_GetAssetKeys : Il2CppSystem.Object
    {
        public AssetBundlePathMatch_GetAssetKeys(IntPtr ptr) : base(ptr)
        {
        }
        public static bool Prefix(string groupName, ref Il2CppSystem.Collections.Generic.List<string> __result)
        {
            //ModComponent.Log.LogInfo(assetGroup);
            if (ResourceCreator.OurFiles.ContainsKey(groupName))
            {
                Il2CppSystem.Collections.Generic.List<string> keys = new Il2CppSystem.Collections.Generic.List<string>();
                foreach(string key in ResourceCreator.OurFiles[groupName].Keys)
                {
                    keys.Add(key);
                }
                __result = keys;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    [HarmonyPatch(typeof(AssetBundlePathMatch), nameof(AssetBundlePathMatch.IsExist))]
    public sealed class AssetBundlePathMatch_IsExist : Il2CppSystem.Object
    {
        public AssetBundlePathMatch_IsExist(IntPtr ptr) : base(ptr)
        {
        }
        [HarmonyPrefix]
        public static bool Prefix(string groupName, string assetName, ref bool __result)
        {
            //ModComponent.Log.LogInfo($"GetAssetData Group:{groupName} Asset:{assetName}");
            if (ResourceCreator.OurFiles.ContainsKey(groupName))
            {
                __result = ResourceCreator.OurFiles[groupName].ContainsKey(assetName);
                return false;
            }
            else
            {
                return true;
            }
        }
    }*/
}
