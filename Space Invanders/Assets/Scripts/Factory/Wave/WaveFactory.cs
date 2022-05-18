using System;
using UnityEngine;
using WaveSystem;

namespace Factory.Wave
{
    [CreateAssetMenu(menuName = "Factory/Wave Factory", order = 0)]
    public class WaveFactory : ScriptableObject
    {
        [SerializeField] private WaveConfiguration _defaultConfiguraion;
        
        public WaveConfiguration Get(WaveType typeWave)
        {
            switch (typeWave)
            {
                case WaveType.Default:
                    return _defaultConfiguraion;
                default:
                    throw new Exception("no such configuration");
            }
        }
    }
}