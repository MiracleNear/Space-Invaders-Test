using System;
using Factory;
using HealthSystem;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Heath))]
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> Died;
        
        public EnemyCost EnemyCost;
        
        private Heath _heath;

        private void Awake()
        {
            _heath = GetComponent<Heath>();
        }

        private void OnEnable()
        {
            _heath.HealthZeroReached += OnHealthZeroReached;
        }

        private void OnDisable()
        {
            _heath.HealthZeroReached -= OnHealthZeroReached;
        }

        private void OnHealthZeroReached()
        {
            Died?.Invoke(this);
            
            Destroy(gameObject);
        }
    }
}