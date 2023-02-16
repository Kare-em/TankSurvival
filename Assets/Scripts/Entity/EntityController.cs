using UnityEngine;

namespace Entity
{
    public abstract class EntityController : MonoBehaviour
    {
        protected EntityModel _model;

        public void DealDamage(float damage)
        {
            _model.DealDamage(damage);
        }

        protected void SubscribeOnDead()
        {
            _model.Dead += OnDead;
        }

        private void OnDisable()
        {
            _model.Dead -= OnDead;
        }

        protected virtual void OnDead()
        {
        }
    }
}