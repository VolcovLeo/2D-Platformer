using System;
using UnityEngine;

namespace Platformer
{
    public class Coin : MonoBehaviour
    {
        public event Action<Coin> Collected;

        private bool _isCollected;

        private void Awake()
        {
            gameObject.tag = "Coin";
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isCollected)
                return;

            if (other.TryGetComponent<PlayerController>(out var player))
            {
                _isCollected = true;
                Collected?.Invoke(this);
            }
        }
    }
}
