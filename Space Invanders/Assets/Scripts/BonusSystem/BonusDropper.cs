using Enemies;
using UnityEngine;
using WaveSystem;
using Random = UnityEngine.Random;

namespace BonusSystem
{
    public class BonusDropper : MonoBehaviour
    {
        [SerializeField] private Bonus[] _allBonus;
        
        private WaveGenerator _waveGenerator;

        private void Awake()
        {
            _waveGenerator = FindObjectOfType<WaveGenerator>();
        }

        private void OnEnable()
        {
            _waveGenerator.EnemyCreated += OnEnemyCreated;
        }

        private void OnDisable()
        {
            _waveGenerator.EnemyCreated -= OnEnemyCreated;
        }

        private void OnEnemyCreated(Enemy enemy)
        {
            enemy.Died += OnEnemyDied;
        }

        private void OnEnemyDied(Enemy enemy)
        {
            float randomValue = Random.value;

            if (randomValue > 0.25 && randomValue < 0.35)
            {
                int randomIndexBonus = Random.Range(0, _allBonus.Length);

                Instantiate(_allBonus[randomIndexBonus], enemy.transform.position, Quaternion.identity);
            }
        }
    }
}