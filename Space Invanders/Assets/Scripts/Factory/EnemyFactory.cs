using System;
using Enemies;
using UnityEngine;

namespace Factory
{
    [CreateAssetMenu(menuName = "Factory/Enemy Factory", order = 0)]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private Enemy _templateLowEnemy, _templateMediumEnemy, _templateHighEnemy;
        
        public Enemy Get(EnemyCost enemyCost, Vector2 position)
        {
            switch (enemyCost)
            {
                case EnemyCost.Low:
                    return Instantiate(_templateLowEnemy, position, Quaternion.identity);
                case EnemyCost.Medium:
                    return Instantiate(_templateMediumEnemy, position, Quaternion.identity);
                case EnemyCost.High:
                    return Instantiate(_templateHighEnemy, position, Quaternion.identity);
                default:
                    throw new Exception("no such template");

            }
        }
    }
}