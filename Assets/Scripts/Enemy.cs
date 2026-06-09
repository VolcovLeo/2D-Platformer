using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Health))]

    public class Enemy : MonoBehaviour
    {
        private void Awake()
        {
            Health health = GetComponent<Health>();
            health.Died += Die;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}