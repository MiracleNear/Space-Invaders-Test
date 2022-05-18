using System;
using System.Linq;
using InputSystem;
using UnityEngine;
using WeaponSystem;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Weapon[] _weapons;
        private Weapon _weapon;
        private DekstopInput _dekstopInput;
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;

        private void Awake()
        {
            _dekstopInput = FindObjectOfType<DekstopInput>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _weapons = GetComponents<Weapon>();
        }

        private void Start()
        {
            _weapon = _weapons.FirstOrDefault(weapon => weapon is Weapon);
            
            _weapon.Enable();
        }

        private void OnEnable()
        {
            _dekstopInput.MovePressed += OnMovePressed;
            _dekstopInput.MoveDepressed += OnMoveDepressed;
            _dekstopInput.ShotPressed += OnShotPressed;
        }

        private void OnDisable()
        {
            _dekstopInput.MovePressed -= OnMovePressed;
            _dekstopInput.MoveDepressed -= OnMoveDepressed;
            _dekstopInput.ShotPressed -= OnShotPressed;
        }

        private void OnMoveDepressed()
        {
            _direction = Vector2.zero;
        }

        private void OnShotPressed()
        {
            if(!_weapon.TryShoot()) return;
            
            _weapon.Shoot(Vector2.up);
        }

        private void OnMovePressed(Vector2 input)
        {
            _direction = input;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _direction * _speed;
        }

        public void SetWeapon<T>() where T : Weapon
        {
            _weapon = _weapons.FirstOrDefault(weapon => weapon is T);
            
            _weapon.Enable();
            
            _weapon.WeaponEnded += OnWeaponEnded;
        }

        private void OnWeaponEnded()
        {
            _weapon.WeaponEnded -= OnWeaponEnded;
            
            SetWeapon<Weapon>();
        }
    }
}
