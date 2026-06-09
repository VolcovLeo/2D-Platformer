using UnityEngine;

namespace Platformer
{
    public class EnemyTargetDetector : MonoBehaviour
    {
        [SerializeField] private float _detectionRadius = 5f;

        public PlayerController Target { get; private set; }

        public bool HasTarget => Target != null;

        private void Update()
        {
            Target = null;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out PlayerController player))
                {
                    Target = player;
                    return;
                }
            }
        }
    }
}
