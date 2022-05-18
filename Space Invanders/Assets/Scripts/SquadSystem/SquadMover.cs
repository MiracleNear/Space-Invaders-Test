using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SquadSystem
{
    public class SquadMover : ISquadUpdate
    {
        private float _speedPerUnit;
        private Vector2 _direction;
        private Rigidbody2D _rigidbody;
        private Border[] _borderMap;
        private Vector2 _sizeSquad;

        public SquadMover(Border[] borderMap, Rigidbody2D rigidbody, Vector2 sizeSquad, float speedPerUnit)
        {
            _direction = ChooseStartRandomDirectionMove(new Vector2[]
            {
                Vector2.left,
                Vector2.right,
            });

            _borderMap = borderMap;
            _sizeSquad = sizeSquad;
            _rigidbody = rigidbody;
            _speedPerUnit = speedPerUnit;
        }

        public void UpdateSquad()
        {
            float lengthStep = _speedPerUnit * Time.deltaTime;
                
            if (TryMove(_direction, lengthStep))
            {
                _rigidbody.MovePosition(_rigidbody.position + _direction * lengthStep);
            }
            else
            {
                _direction *= -1f;
            }
            
        }

        public void Add(Enemy enemy)
        {
            
        }

        private Vector2 ChooseStartRandomDirectionMove(Vector2[] direcrtions)
        {
            return direcrtions[Random.Range(0, direcrtions.Length)];
        }

        private bool TryMove(Vector2 direction, float length)
        {
            foreach (var border in _borderMap)
            {
                Vector2 point = _rigidbody.position + _sizeSquad.x * direction + direction * length;
                
                if (border.Contains(point))
                {
                    return false;
                }
                
            }

            return true;
        }

        
    }
}