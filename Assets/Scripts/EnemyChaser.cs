using UnityEngine;

namespace Platformer
{
    public class EnemyChaser : MonoBehaviour
    {
        [SerializeField] private float _visionDistance = 5f;

        private Transform _player;

        public bool CanSeePlayer { get; private set; }

        private void Start()
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            _player = player.transform;
        }

        private void Update()
        {
            float distance = (_player.position - transform.position).sqrMagnitude;

            CanSeePlayer = distance <= _visionDistance * _visionDistance;
        }

        public Transform GetPlayer()
        {
            return _player;
        }
    }
}
