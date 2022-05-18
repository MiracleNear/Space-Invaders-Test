using System;
using UnityEngine;

namespace WeaponSystem
{
    public class ExplosiveWeapon : Weapon
    {
        public override event Action WeaponEnded;

        [SerializeField] private int _countBullet;

        private int _currentCountBullet;
        
        public override void Enable()
        {
            _currentCountBullet = _countBullet;
        }

        public override bool TryShoot()
        {
            if (_currentCountBullet == 0)
            {
                WeaponEnded?.Invoke();
                
                return false;
            }

            return base.TryShoot();
        }

        public override void Shoot(Vector2 direction)
        {
            base.Shoot(direction);
            
            _currentCountBullet -= 1;
        }
    }
}