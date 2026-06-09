using System;
using UnityEngine;

namespace Platformer
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;

        public event Action Died;

        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Died?.Invoke();
            }
        }

        public void Heal(int value)
        {
            _currentHealth += value;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}
