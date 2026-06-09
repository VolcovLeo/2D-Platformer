using UnityEngine;

namespace Platformer
{
    public class EnemyCombat : MonoBehaviour
    {
        [SerializeField] private float _attackDistance = 1f;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _attackCooldown = 1f;

        private Transform _player;
        private float _timer;

        private void Start()
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            _player = player.transform;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer < _attackCooldown)
                return;

            float distance = (_player.position - transform.position).sqrMagnitude;

            if (distance <= _attackDistance * _attackDistance)
            {
                if (_player.TryGetComponent(out Health health))
                {
                    health.TakeDamage(_damage);
                }

                _timer = 0f;
            }
        }
    }
}
