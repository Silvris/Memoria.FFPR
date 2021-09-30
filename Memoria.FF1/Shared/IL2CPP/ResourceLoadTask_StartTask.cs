using HarmonyLib;
using Last.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Memoria.FFPR.IL2CPP
{
    [HarmonyPatch(typeof(ResourceLoadTask), nameof(ResourceLoadTask.StartTask))]
    public sealed class ResourceLoadTask_StartTask : Il2CppSystem.Object
    {
        public ResourceLoadTask_StartTask(IntPtr ptr) : base(ptr)
        {
        }

        public static bool Prefix(MonoBehaviour mono, ResourceLoadTask __instance)
        {
            //ModComponent.Log.LogInfo($"[ResourceLoadTask.StartTask] Loaded asset:{__instance.GetAssetName()}");
            return true;//don't skip for testing
        }
    }
}
