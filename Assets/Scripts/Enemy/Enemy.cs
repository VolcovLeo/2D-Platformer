using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Health))]

    public class Enemy : MonoBehaviour
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _health.Died += Die;
        }

        private void OnDestroy()
        {
            if (_health != null)
            {
                _health.Died -= Die;
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}