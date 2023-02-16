using System.Collections;
using Tank;
using UnityEngine;

namespace Monster
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] private bool _active;
        [SerializeField] private Transform[] points;
        [SerializeField] private MonstersConfig _config;
        [SerializeField] private int _maxActiveCount;
        [SerializeField] private TankSpawner _tankSpawner;
        
        private int _currentCount;

        private void Start()
        {
            StartCoroutine(RepeatSpawn());
        }

        private IEnumerator RepeatSpawn()
        {
            while (_active)
            {
                if (_maxActiveCount > _currentCount)
                    RandomSpawn();
                yield return new WaitForSeconds(1f);
            }
        }

        private void RandomSpawn()
        {
            if(!_tankSpawner.Player)
                return;
            var pointIndex = Random.Range(0, points.Length);
            var monsterIndex = Random.Range(0, _config.MonsterTypes.Length);
            var monster = Instantiate(_config.MonsterTypes[monsterIndex].MonsterPrefab, points[pointIndex].position,
                points[pointIndex].rotation);
            var monsterController = monster.AddComponent<MonsterController>();
            var monsterModel = (MonsterModel)_config.MonsterTypes[monsterIndex].Clone();
            monsterController.Initialize(monsterModel, _tankSpawner.Player.transform);
            monsterModel.Dead += OnDead;
            _currentCount++;
        }

        private void OnDead()
        {
            RandomSpawn();
        }
    }
}