using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Entity
{
    [Serializable]
    public abstract class EntityModel
    {
        public Action Dead;

        public float Speed => _speed;
        public float AngularSpeed => _angularSpeed;
        
        [SerializeField] private float hp;
        [SerializeField] [Range(0f, 1f)] private float _shield;
        [SerializeField] private float _speed;
        [SerializeField] private float _angularSpeed;

        public void DealDamage(float bulletModelDamage)
        {
            var modelDamage = bulletModelDamage * _shield;
            hp -= modelDamage;
            if (hp <= 0f)
            {
                hp = 0f;
                Dead.Invoke();
                Debug.Log("Damaged " + modelDamage);
            }
        }

        public object Clone()
        {
            var copy = this.Serialize();
            return copy.Deserialize();
        }
    }
}