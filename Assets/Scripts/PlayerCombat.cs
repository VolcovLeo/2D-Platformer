using UnityEngine;

namespace Platformer
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private InputService _inputService;
        [SerializeField] private float _attackRadius = 1.5f;
        [SerializeField] private int _damage = 20;

        private void Awake()
        {
            Health health = GetComponent<Health>();
            health.Died += Die;
        }

        private void Update()
        {
            if (_inputService.AttackPressed)
            {
                Attack();
            }
        }

        private void Attack()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attackRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Enemy enemy))
                {
                    if (enemy.TryGetComponent(out Health health))
                    {
                        health.TakeDamage(_damage);
                    }
                }
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
