using System;
using System.Linq;
using Enemies;
using Factory;
using Factory.Wave;
using SquadSystem;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WaveSystem
{
    public class WaveGenerator : MonoBehaviour
    {
        public event Action<Enemy> EnemyCreated;
        public event Action<Squad> SquadCreated; 
        
        [SerializeField] private WaveFactory _waveFactory;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private Squad _squad;

        private void Start()
        {
            WaveConfiguration waveConfiguration = _waveFactory.Get(WaveType.Default);

            ShapeWave shapeWave = waveConfiguration.ShapeWave;

            Vector2[] shapePoints = shapeWave.Shape();

            EnemyCost[] enemyCosts = Enum.GetValues(typeof(EnemyCost)).Cast<EnemyCost>().ToArray();

            Squad squad = Instantiate(_squad, shapeWave.Center, quaternion.identity);
            
            SquadCreated?.Invoke(squad);
            
            squad.Init(shapeWave.Extents);

            foreach (var point in shapePoints)
            {
                EnemyCost randomEnemy = enemyCosts[Random.Range(0, enemyCosts.Length)];

                Enemy enemy = _enemyFactory.Get(randomEnemy, point);
                
                squad.Add(enemy);
                
                EnemyCreated?.Invoke(enemy);
            }
            
        }
    }
}