using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "WeaponsConfig", menuName = "WeaponsConfig", order = 0)]
    public class WeaponsConfig : ScriptableObject
    {
        public WeaponType[] WeaponTypes => _weaponTypes;
        
        [SerializeField] private WeaponType[] _weaponTypes;
    }
}