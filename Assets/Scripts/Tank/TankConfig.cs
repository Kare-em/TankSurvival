using UnityEngine;

namespace Tank
{
    [CreateAssetMenu(fileName = "TankConfig", menuName = "TankConfig", order = 0)]
    public class TankConfig : ScriptableObject
    {
        public TankModel TankModel => _tankModel;
        [SerializeField] private TankModel _tankModel;
    }
}