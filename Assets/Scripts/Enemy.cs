using UnityEngine;

namespace Platformer
{
    public class Enemy : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerController player))
            {
                player.GetType();
            }
        }
    }
}
