using System;
using Entity;
using Unity.VisualScripting;
using UnityEngine;

namespace Monster
{
    [Serializable]
    public class MonsterModel : EntityModel, ICloneable
    {
        public float Damage => _damage;
        
        [SerializeField] private float _damage;
    }
}