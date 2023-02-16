using System;
using System.Collections.Generic;
using Bullet;
using Unity.VisualScripting;
using UnityEngine;

namespace Pool
{
    public class BulletsPool : MonoBehaviour
    {
        private List<GameObject> _bullets;
        private GameObject _bulletPrefab;

        public void Initialize(GameObject bulletPrefab, int count)
        {
            _bulletPrefab = bulletPrefab;
            _bullets = new List<GameObject>();
            for (int i = 0; i < count; i++)
            {
                CreateBullet();
            }
        }

        public GameObject GetBullet()
        {
            foreach (var bullet in _bullets)
            {
                if (!bullet.activeInHierarchy)
                    return bullet;
            }

            return CreateBullet();
        }

        public void DeactivateBullet(GameObject bullet)
        {
            bullet.SetActive(false);
        }

        private GameObject CreateBullet()
        {
            var bullet = Instantiate(_bulletPrefab);
            var bulletController = bullet.AddComponent<BulletController>();
            bulletController.Initialize();
            bullet.SetActive(false);
            _bullets.Add(bullet);
            return bullet;
        }
    }
}