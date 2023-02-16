using System;
using Monster;
using UnityEngine;

namespace Bullet
{
    public class BulletController : MonoBehaviour
    {
        public Action<GameObject> Hit;

        private BulletModel _bulletModel;
        private BulletView _bulletView;
        
        public void Initialize()
        {
            _bulletModel = new BulletModel();
            _bulletView = GetComponent<BulletView>();
        }

        public void Shoot(float damage, Vector3 speed)
        {
            _bulletModel.Damage = damage;
            _bulletView.Shoot(speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Monster"))
            {
                other.GetComponent<MonsterController>().DealDamage(_bulletModel.Damage);
            }

            Hit.Invoke(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Hit.Invoke(gameObject);
        }
    }
}