using Character;
using UnityEngine;
using WeaponSystem;

namespace BonusSystem
{
    public class ExplosionBulletBonus : Bonus
    {
        public override void Affect(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out Player player))
            {
                player.SetWeapon<ExplosiveWeapon>();
                
                Destroy();
            }
        }
    }
}