using UnityEngine;
using UnityEngine.AI;

namespace Monster
{
    public class MonsterView : MonoBehaviour
    {
        private NavMeshAgent _navMesh;

        public void SetSpeed(float speed, float angularSpeed)
        {
            _navMesh.speed = speed;
            _navMesh.angularSpeed = angularSpeed;
        }

        public void UpdateDestination(Vector3 position)
        {
            _navMesh.destination = position;
        }

        private void Awake()
        {
            _navMesh = GetComponent<NavMeshAgent>();
        }
    }
}