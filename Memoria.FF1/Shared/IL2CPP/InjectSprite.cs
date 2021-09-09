using System;
using System.IO;
using UnityEngine;
namespace Memoria.FFPR.IL2CPP
{
    [Serializable]
    public class InjectSprite : Il2CppSystem.Object
    {
        public InjectSprite(IntPtr ptr) : base(ptr)
        {
        }

        public InjectSprite()
        {
            _rect = new Rect();
            _pivot = new Vector2();
            _pixelsPerUnit = 0.0F;
        }
        public InjectSprite(BinaryReader br)
        {
            _rect = new Rect();
            _pivot = new Vector2();
            _rect.x = br.ReadSingle();
            _rect.y = br.ReadSingle();
            _rect.width = br.ReadSingle();
            _rect.height = br.ReadSingle();
            _pivot.x = br.ReadSingle();
            _pivot.y = br.ReadSingle();
            _pixelsPerUnit = br.ReadSingle();
            br.Close();
        }

        private Rect _rect;
        private Vector2 _pivot;
        private Single _pixelsPerUnit;

        public Rect rect { get => _rect; set => _rect = value; }
        public Vector2 pivot { get => _pivot; set => _pivot = value; }
        public Single pixelsPerUnit { get => _pixelsPerUnit; set => _pixelsPerUnit = value; }
    }
}