using UnityEngine;

namespace Tank
{
    public class TankView : MonoBehaviour
    {
        public Transform WeaponParent => _weaponParent;
        
        [SerializeField] private Transform _weaponParent;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(float direction)
        {
            _rigidbody.AddForce(direction * Time.fixedDeltaTime * transform.forward, ForceMode.VelocityChange);
        }

        public void Rotate(float angle)
        {
            transform.Rotate(angle * Time.fixedDeltaTime * Vector3.up);
        }
    }
}