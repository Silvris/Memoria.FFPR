using System;
using UnityEngine;
namespace Memoria.FFPR.IL2CPP
{
    [Serializable]
    public class InjectSprite : Il2CppSystem.Object
    {
        public InjectSprite(IntPtr ptr) : base(ptr)
        {
        }

        public Rect rect;
        public Vector2 pivot;
        public Single pixelsPerUnit;
        public InjectSprite()
        {
            rect = new Rect();
            pivot = new Vector2();
            pixelsPerUnit = 1;
        }
    }
}