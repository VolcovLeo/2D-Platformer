using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(EnemyTargetDetector))]

    public class EnemyCombat : MonoBehaviour
    {
        [SerializeField] private float _attackDistance = 1f;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _attackCooldown = 1f;

        private EnemyTargetDetector _detector;

        private float _timer;

        private void Awake()
        {
            _detector = GetComponent<EnemyTargetDetector>();
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_detector.HasTarget == false)
                return;

            if (_timer < _attackCooldown)
                return;

            float distanceSquared = (_detector.Target.transform.position - transform.position).sqrMagnitude;

            if (distanceSquared <= _attackDistance * _attackDistance)
            {
                if (_detector.Target.TryGetComponent(out Health health))
                {
                    health.TakeDamage(_damage);
                }

                _timer = 0f;
            }
        }
    }
}
