using System;
using HealthSystem;
using UnityEngine;

namespace WeaponSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet: MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        
        private Rigidbody2D _rigidbody;
        private Action _destroyed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Init(Vector2 direction, Action destroyed)
        {
            _rigidbody.velocity = direction * _speed;
            _destroyed = destroyed;
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            ApplyDamage(other.collider);
            Destroy();
        }

        protected void ApplyDamage(Collider2D hit)
        {
            if (hit.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
            }
        }

        protected void Destroy()
        {
            _destroyed.Invoke();
            Destroy(this.gameObject);
        }
    }
}