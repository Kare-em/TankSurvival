using Cinemachine;
using UnityEngine;
using Weapon;

namespace Tank
{
    public class TankSpawner : MonoBehaviour
    {
        public GameObject Player { get; private set; }
        [SerializeField] private Transform _point;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private TankConfig _tankConfig;
        [SerializeField] private WeaponsConfig _weaponsConfig;
        [SerializeField] private CinemachineVirtualCamera _camera;

        private void Awake()
        {
            Player = Instantiate(_prefab, _point.position, _point.rotation);
            var tankController = Player.AddComponent<TankController>();
            tankController.Initialize((TankModel)_tankConfig.TankModel.Clone());
            var tankView = Player.GetComponent<TankView>();
            var weaponController = tankView.WeaponParent.gameObject.AddComponent<WeaponController>();
            weaponController.Initialize(_weaponsConfig);
            _camera.Follow = _camera.LookAt = Player.transform;
        }
    }
}