using System;
using UnityEngine;

namespace HealthSystem
{
    public class Heath : MonoBehaviour, IDamageable
    {
        public event Action HealthZeroReached; 
        
        [SerializeField] private int _numberHearts;

        private int _currentHealth;

        private void Start()
        {
            _currentHealth = _numberHearts;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _numberHearts);

            if (_currentHealth == 0)
            {
                HealthZeroReached?.Invoke();
            }
        }
    }
}