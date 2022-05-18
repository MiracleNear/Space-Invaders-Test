using System;
using UnityEngine;

namespace WeaponSystem
{
    public class DefaultWeapon : Weapon
    {
        public override event Action WeaponEnded;

        public override bool TryShoot()
        {
            return base.TryShoot();
        }

        public override void Shoot(Vector2 direction)
        {
            base.Shoot(direction);
        }

        public override void Enable()
        {
           
        }
        
    }
}