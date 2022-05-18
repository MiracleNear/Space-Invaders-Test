using System;
using UnityEngine;

namespace WaveSystem
{
    public class WaveConfiguration : ScriptableObject
    {
        public virtual ShapeWave ShapeWave { get; }
    }
}