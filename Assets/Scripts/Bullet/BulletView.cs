using UnityEngine;

namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private Rigidbody GetRigidbody()
        {
            if (!_rigidbody)
                _rigidbody = GetComponent<Rigidbody>();

            return _rigidbody;
        }

        public void Shoot(Vector3 speed)
        {
            GetRigidbody().velocity = Vector3.zero;
            GetRigidbody().AddForce(speed, ForceMode.VelocityChange);
        }
    }
}