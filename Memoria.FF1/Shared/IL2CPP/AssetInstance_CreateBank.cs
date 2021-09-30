using HarmonyLib;
using Last.Management.Audio;
using SEAD;
using Memoria.FFPR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSystem.Runtime.InteropServices;
using UnityEngine;

namespace Memoria.FFPR.IL2CPP
{
    [HarmonyPatch(typeof(AssetInstance), nameof(AssetInstance.CreateBank))]
    public sealed class AssetInstance_CreateBank : Il2CppSystem.Object
    {
        public AssetInstance_CreateBank(IntPtr ptr) : base(ptr)
        { 
        }

        public static void Postfix(AssetInstance __instance)
        {
            try
            {
                /*
                ModComponent.Log.LogInfo(__instance.assetData.GetType());
                TextAsset asset = __instance.assetData;
                BinaryTextAsset test = asset.Cast<BinaryTextAsset>();
                if (test is BinaryTextAsset)
                {
                    ModComponent.Log.LogInfo("TextAsset is BinaryTextAsset");
                    byte[] bytes = test.bytes;
                    IntPtr unmanaged = Marshal.AllocHGlobal(bytes.Length);
                    Marshal.Copy(bytes, 0, unmanaged, bytes.Length);
                    ulong hbank = 0;
                    API.seadCreateBank(ref hbank, unmanaged);
                    __instance.seadHBank = hbank;
                }
                else
                {
                    ModComponent.Log.LogInfo("TextAsset is not BinaryTextAsset");
                }*/
            }
            catch(Exception ex)
            {
                ModComponent.Log.LogError(ex);
            }

        }
    }
}
