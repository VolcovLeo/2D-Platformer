using UnityEngine;

namespace Platformer
{
    public class PlayerCoinCollector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                coin.Collect();
            }
        }
    }
}
