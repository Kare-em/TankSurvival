using UnityEngine;

namespace Monster
{
    [CreateAssetMenu(fileName = "MonstersConfig", menuName = "MonstersConfig", order = 0)]
    public class MonstersConfig : ScriptableObject
    {
        public MonsterType[] MonsterTypes => _monsterTypes;
        [SerializeField] private MonsterType[] _monsterTypes;
    }
}