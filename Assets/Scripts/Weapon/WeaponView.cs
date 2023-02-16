using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class WeaponView : MonoBehaviour
    {
        public Transform Muzzle => _muzzle;

        [SerializeField] private Transform _muzzle;
    }
}