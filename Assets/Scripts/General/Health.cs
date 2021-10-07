using System;
using UnityEngine;

namespace General
{
    public class Health : MonoBehaviour
    {
        public event Action OnDamageTaken;
        public event Action OnDied;
        
        [SerializeField] private float _health = 100f;
        private bool _isDead;

        public bool IsDead() => _isDead;
    
        public void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health > 0)
            {
                OnDamageTaken?.Invoke();
            }
            if (_health <= 0)
            {
                Die();
                OnDied?.Invoke();
            }
        }
    
        private void Die()
        {
            if (_isDead) return;
            
            _isDead = true;
            Debug.Log(gameObject.name + " has died!");
        }
    }
}
