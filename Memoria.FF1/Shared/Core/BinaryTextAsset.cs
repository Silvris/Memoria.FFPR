using System;
using UnityEngine;
namespace Memoria.FFPR.Core
{
    [Serializable]
    public class BinaryTextAsset : TextAsset
    {
        public BinaryTextAsset(IntPtr ptr) : base(ptr)
        {
        }

        public BinaryTextAsset()
        {
            _bytes = new byte[1];
        }

        public BinaryTextAsset(byte[] Bytes)
        {
            _bytes = Bytes;
        }

        private byte[] _bytes;

        public new byte[] bytes { get => _bytes; set => _bytes = value; }
    }
}