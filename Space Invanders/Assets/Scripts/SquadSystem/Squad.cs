using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using WeaponSystem;

namespace SquadSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Squad : MonoBehaviour
    {
        public event Action SquadDestroyed;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _rechargeTimeMax;
        [SerializeField] private float _rechargeTimeMin;
        
        private List<Enemy> _enemies;
        private List<ISquadUpdate> _squadUpdates;
        private Vector2 _center;
        private Vector2 _size;

        private bool _isSquadEmpty;
        public void Init(Vector2 size)
        {
            Border[] borders = FindObjectsOfType<Border>();
            _enemies = new List<Enemy>();

            _squadUpdates = new List<ISquadUpdate>()
            {
                new SquadMover(borders, GetComponent<Rigidbody2D>(), size, _speed),
                new SquadShooting(_rechargeTimeMax, _rechargeTimeMin),
            };
        }
        
        public void Add(Enemy enemy)
        {
            _enemies.Add(enemy);

            enemy.transform.parent = transform;
            
            ((SquadShooting)_squadUpdates[1]).Add(enemy.GetComponent<Weapon>());
            
            enemy.Died += OnDied;
        }

        public void Remove(Enemy enemy)
        {
            ((SquadShooting)_squadUpdates[1]).Remove(enemy.GetComponent<Weapon>());
            _enemies.Remove(enemy);
        }
        

        private void FixedUpdate()
        {
            if (_enemies.Count > 0)
            {
                foreach (ISquadUpdate squadUpdate in _squadUpdates)
                {
                    squadUpdate.UpdateSquad();
                }
            }
        }

        private void OnDied(Enemy enemy)
        {
            enemy.Died -= OnDied;
            
            Remove(enemy);

            if (_enemies.Count == 0)
            {
                SquadDestroyed?.Invoke();
            }
        }
        
    }
}