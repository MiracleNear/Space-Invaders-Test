using UnityEngine;

namespace WeaponSystem
{
    public class ExplosiveBullet : Bullet
    {
        [SerializeField] private float _radius;
        
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, _radius);
            
            ApplyDamage(other.collider);
            
            foreach (var target in hitTargets)
            {
                ApplyDamage(target);
            }
            
            Destroy();
        }
    }
}