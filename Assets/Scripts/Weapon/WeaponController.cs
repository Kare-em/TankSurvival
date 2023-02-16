using System;
using System.Collections.Generic;
using Bullet;
using Pool;
using UnityEngine;

namespace Weapon
{
    public class WeaponController : MonoBehaviour
    {
        private WeaponsConfig _weaponsConfig;
        private WeaponModel _weaponModel;
        private WeaponView _weaponView;
        private List<BulletsPool> _pool;
        private List<GameObject> _weapons;
        private int _currentWeaponIndex;
        private float _reloading;
        private bool _ready;

        public void Initialize(WeaponsConfig weaponsConfig)
        {
            _weaponsConfig = weaponsConfig;
            _weapons = new List<GameObject>();
            _pool = new List<BulletsPool>();
            foreach (var weapon in _weaponsConfig.WeaponTypes)
            {
                Spawn(weapon.WeaponPrefab);
                var pool = gameObject.AddComponent<BulletsPool>();
                pool.Initialize(weapon.BulletPrefab, weapon.PoolBulletCount);
                _pool.Add(pool);
            }

            _currentWeaponIndex = 0;
            SetWeapon(_currentWeaponIndex);
        }

        private void Spawn(GameObject weapon)
        {
            var newWeapon = Instantiate(weapon, transform);
            newWeapon.SetActive(false);
            _weapons.Add(newWeapon);
        }

        private void Update()
        {
            if (_reloading < 0f)
                _ready = true;
            else
                _reloading -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Q))
                PreviewWeapon();
            if (Input.GetKeyDown(KeyCode.E))
                NextWeapon();
            if (Input.GetKeyDown(KeyCode.X))
                TryShoot();
        }

        private void PreviewWeapon()
        {
            _weapons[_currentWeaponIndex].SetActive(false);
            _currentWeaponIndex--;
            if (_currentWeaponIndex < 0)
                _currentWeaponIndex = _weapons.Count - 1;
            SetWeapon(_currentWeaponIndex);
        }

        private void NextWeapon()
        {
            _weapons[_currentWeaponIndex].SetActive(false);
            _currentWeaponIndex++;
            if (_currentWeaponIndex >= _weapons.Count)
                _currentWeaponIndex = 0;
            SetWeapon(_currentWeaponIndex);
        }

        private void SetWeapon(int index)
        {
            _weaponModel = _weaponsConfig.WeaponTypes[index];
            _weaponView = _weapons[index].GetComponent<WeaponView>();
            _weapons[index].SetActive(true);
            ResetLoading();
        }

        private void ResetLoading()
        {
            _ready = false;
            _reloading = _weaponsConfig.WeaponTypes[_currentWeaponIndex].ReloadingTime;
        }

        private void TryShoot()
        {
            if (!_ready)
                return;
            ResetLoading();
            var bullet = _pool[_currentWeaponIndex].GetBullet();
            bullet.transform.position = _weaponView.Muzzle.position;
            bullet.transform.rotation = _weaponView.Muzzle.rotation;
            Debug.Log(_weaponView.Muzzle.rotation.eulerAngles);
            var bulletController = bullet.GetComponent<BulletController>();
            bullet.SetActive(true);
            bulletController.Shoot(_weaponModel.Damage, _weaponView.Muzzle.forward * _weaponModel.Speed);
            bulletController.Hit += OnHit;
        }

        private void OnHit(GameObject bullet)
        {
            _pool[_currentWeaponIndex].DeactivateBullet(bullet);
        }
    }
}