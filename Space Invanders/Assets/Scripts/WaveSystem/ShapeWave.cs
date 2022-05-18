using UnityEngine;

namespace WaveSystem
{
    [System.Serializable]
    public abstract class ShapeWave
    {
        public abstract Vector2 Center { get; }
        public abstract Vector2 Extents { get; }
        
        public abstract Vector2[] Shape();
    }
}