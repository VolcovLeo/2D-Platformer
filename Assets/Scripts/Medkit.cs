using UnityEngine;

namespace Platformer
{
    public class Medkit : MonoBehaviour
    {
        [SerializeField] private int _healAmount = 25;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.Heal(_healAmount);

                Destroy(gameObject);
            }
        }
    }
}
