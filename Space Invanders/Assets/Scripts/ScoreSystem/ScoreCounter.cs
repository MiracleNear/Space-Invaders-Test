using Enemies;
using UnityEngine;
using WaveSystem;

namespace ScoreSystem
{
    [RequireComponent(typeof(ScoreView))]
    public class ScoreCounter : MonoBehaviour
    {
        private WaveGenerator _waveGenerator;
        private ScoreView _scoreView;
        private int _score;
        
        private void Awake()
        {
            _waveGenerator = FindObjectOfType<WaveGenerator>();
            _scoreView = GetComponent<ScoreView>();
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
            enemy.Died += OnDied;
        }

        private void OnDied(Enemy enemy)
        {
            enemy.Died -= OnDied;

            _score += (int) enemy.EnemyCost;
            
            _scoreView.UpdateScore(_score);
        }
    }
}