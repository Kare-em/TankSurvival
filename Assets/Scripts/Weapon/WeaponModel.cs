using UnityEngine;

namespace Weapon
{
    public class WeaponModel
    {
        public float Damage => _damage;
        public float ReloadingTime => _reloadingTime;
        public float Speed => _speed;
        public int PoolBulletCount => _poolBulletCount;
        [SerializeField] private float _damage;
        [SerializeField] private float _reloadingTime;
        [SerializeField] private float _speed;
        [SerializeField] private int _poolBulletCount;
    }
}