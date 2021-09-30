using UnityEngine;

namespace Enemy
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _health = 100f;
        private bool _isDead;

        public bool IsDead() => _isDead;
    
        public void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Die();
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
