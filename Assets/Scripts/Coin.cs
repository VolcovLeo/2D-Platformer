using System;
using UnityEngine;

namespace Platformer
{
    public class Coin : MonoBehaviour
    {
        public event Action<Coin> Collected;

        private bool _isCollected;

        private void OnEnable()
        {
            _isCollected = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isCollected)
                return;

            if (other.TryGetComponent(out PlayerController player))
            {
                _isCollected = true;
                Collected?.Invoke(this);
            }
        }
    }
}
