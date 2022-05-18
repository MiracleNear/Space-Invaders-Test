using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;
using Random = UnityEngine.Random;

namespace SquadSystem
{
    public class SquadShooting : ISquadUpdate
    {
        private List<Weapon> _squadWeapons;
        private float _rechargeTimeMax;
        private float _rechargeTimeMin;
        private float _rechargeTime;
        private float _lastShotTime;
        public SquadShooting(float rechargeTimeMax, float rechargeTimeMin)
        {
            _squadWeapons = new List<Weapon>();
            _rechargeTimeMin = rechargeTimeMin;
            _rechargeTimeMax = rechargeTimeMax;
            _rechargeTime = Random.Range(_rechargeTimeMin, rechargeTimeMax);
            _lastShotTime = _rechargeTime;
        }

        public void Add(Weapon weapon)
        {
            _squadWeapons.Add(weapon);
        }

        public void Remove(Weapon weapon)
        {
            _squadWeapons.Remove(weapon);
        }
        
        public void UpdateSquad()
        {
            if(Time.time - _lastShotTime <= _rechargeTime) return;
            
            List<Weapon> availableWeapons = _squadWeapons.FindAll(weapon => weapon.IsShot == false);

           if(availableWeapons.Count == 0) return;

           int randomWeaponIndex = Random.Range(0, availableWeapons.Count);
           
           availableWeapons[randomWeaponIndex].Shoot(Vector2.down);
            
           
           _rechargeTime = Random.Range(_rechargeTimeMin, _rechargeTimeMax);
           _lastShotTime = Time.time + _rechargeTime;
        }
    }
}