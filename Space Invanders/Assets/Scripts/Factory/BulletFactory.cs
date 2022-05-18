using System;
using UnityEngine;
using WeaponSystem;


namespace Factory
{
    [CreateAssetMenu(menuName = "Factory/Bullet Factory")]
    public class BulletFactory : ScriptableObject
    {
        [SerializeField] private Bullet _template, _explosiveTemplate;
        
        public void Create(BulletType type, Vector2 position, Vector2 direction, Action destroyed)
        {
            switch (type)
            {
                case BulletType.Default:
                    Bullet bullet = Instantiate(_template, position, Quaternion.identity);
                    bullet.Init(direction, destroyed);
                    break;
                case BulletType.Explosive:
                    Bullet explosiveBullet = Instantiate(_explosiveTemplate, position, Quaternion.identity);
                    explosiveBullet.Init(direction, destroyed);
                    break;
                    
                default:
                    throw new Exception("there is no such type of bullet");
            }
        }
    }
}