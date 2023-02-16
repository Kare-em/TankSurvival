using System;
using Entity;
using Tank;
using UnityEngine;
using UnityEngine.AI;

namespace Monster
{
    public class MonsterController : EntityController
    {
        private MonsterView _monsterView;
        private Transform _player;

        public void Initialize(MonsterModel monsterModel, Transform player)
        {
            _model = monsterModel;
            SubscribeOnDead();
            _monsterView = GetComponent<MonsterView>();
            _monsterView.SetSpeed(_model.Speed, _model.AngularSpeed);
            _player = player;
        }

        protected override void OnDead()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            if (_player)
                _monsterView.UpdateDestination(_player.position);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                collision.gameObject.GetComponentInParent<TankController>().DealDamage(((MonsterModel)_model).Damage);
        }
    }
}