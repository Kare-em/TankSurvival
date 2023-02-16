using System;
using UnityEngine;

namespace Monster
{
    [Serializable]
    public class MonsterType : MonsterModel
    {
        [SerializeField] public GameObject MonsterPrefab;
    }
}