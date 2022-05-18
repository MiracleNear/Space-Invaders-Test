using UnityEngine;

namespace WaveSystem
{
    [CreateAssetMenu(menuName = "Configuration/Rectangle Configuration")]
    public class RectangleWaveConfiguration : WaveConfiguration
    {
        public override ShapeWave ShapeWave => _shapeWave;

        [SerializeField] private RectangleShapeWave _shapeWave;
    }
}