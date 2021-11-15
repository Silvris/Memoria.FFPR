using HarmonyLib;
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
    [HarmonyPatch]
    public sealed class ResourceManager_GetAsset : Il2CppSystem.Object
    {
        public ResourceManager_GetAsset(IntPtr ptr) : base(ptr)
        {
        }
        public static MethodBase TargetMethod()
        {
            MethodInfo method = AccessTools.Method(typeof(ResourceManager), "GetAssetData", new Type[] { typeof(string), typeof(string) });
            MethodInfo actual = method.MakeGenericMethod(typeof(Sprite));
            return actual;
        }
        [HarmonyPostfix]
        public static void Postfix(string groupName, string assetName)
        {
            ModComponent.Log.LogInfo(groupName);
            ModComponent.Log.LogInfo(assetName);
        }
        [HarmonyPrefix]
        public static bool Prefix(string groupName, string assetName, ResourceManager __instance, ref Sprite __result)
        {
            ModComponent.Log.LogInfo($"GetAssetData Group:{groupName} Asset:{assetName}");
            if (ResourceCreator.OurFiles.ContainsKey(groupName))
            {
                if (ResourceCreator.OurFiles[groupName].ContainsKey(assetName))
                {
                    string assetKey = ResourceCreator.OurFiles[groupName][assetName];
                    if (__instance.completeAssetDic.ContainsKey(assetKey))
                    {
                        __result = __instance.completeAssetDic[assetKey].Cast<Sprite>();
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
            else
            {
                return true;
            }
        }
    }
}
/*[HarmonyPatch(typeof(ResourceManager),nameof(ResourceManager.IsAssetGroup))]
    public sealed class ResourceManager_IsAssetGroup : Il2CppSystem.Object
    {
        public ResourceManager_IsAssetGroup(IntPtr ptr) : base(ptr)
        {
        }
        public static bool Prefix(string assetGroup, ref bool __result)
        {
            //ModComponent.Log.LogInfo(assetGroup);
            if (ResourceCreator.OurFiles.ContainsKey(assetGroup))
            {
                __result = true;
                return false;
            }
            else
            {
                return true;
            }
        }
    }*/