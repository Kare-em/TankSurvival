using Entity;
using UnityEngine;

namespace Tank
{
    public class TankController : EntityController
    {
        private TankView _tankView;
        private float _speedDirection;
        private float _rotation;

        public void Initialize(TankModel tankModel)
        {
            _model = tankModel;
            SubscribeOnDead();
        }

        protected override void OnDead()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            _tankView = GetComponent<TankView>();
        }


        private void Update()
        {
            _speedDirection = 0f;
            _rotation = 0f;
            if (Input.GetKey(KeyCode.UpArrow))
                _speedDirection = 1f;
            if (Input.GetKey(KeyCode.DownArrow))
                _speedDirection = -1f;
            if (Input.GetKey(KeyCode.LeftArrow))
                _rotation = -1f;
            if (Input.GetKey(KeyCode.RightArrow))
                _rotation = 1f;
        }

        private void FixedUpdate()
        {
            _tankView.Move(_speedDirection * _model.Speed);
            _tankView.Rotate(_rotation * _model.AngularSpeed);
        }
    }
}