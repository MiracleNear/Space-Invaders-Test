using System;
using Factory;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract event Action WeaponEnded;

        [SerializeField] private BulletType _bulletType;
        [SerializeField] private Transform _launchPoint;
        [SerializeField] private BulletFactory _bulletFactory;
        public bool IsShot { get; private set; }

        public virtual bool TryShoot()
        {
            if (IsShot)
            {
                return false;
            }

            return true;
        }

        public virtual void Shoot(Vector2 direction)
        {
            _bulletFactory.Create(_bulletType, _launchPoint.position, direction, OnDestroyedFiredBullet);

            IsShot = true;
        }
        public abstract void Enable();
        
        private void OnDestroyedFiredBullet()
        {
            IsShot = false;
        }
    }
}