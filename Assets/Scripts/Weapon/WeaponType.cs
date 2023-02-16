using System;
using UnityEngine;

namespace Weapon
{
    [Serializable]
    public class WeaponType : WeaponModel
    {
        public GameObject WeaponPrefab => _weaponPrefab;
        public GameObject BulletPrefab => _bulletPrefab;
        
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private GameObject _bulletPrefab;
    }
}