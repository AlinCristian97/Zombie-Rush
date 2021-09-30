using UnityEngine;

namespace Enemy
{
    //TODO: Merge EnemyHealth & PlayerHealth into one single Health component
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] float _hitPoints = 100f;

        private bool _isDead;

        public bool IsDead() => _isDead;
    
        public void TakeDamage(float damage)
        {
            BroadcastMessage("OnDamageTaken");
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                Die();
            }
        }
    
        private void Die()
        {
            if (_isDead) return;
            _isDead = true;
            GetComponent<Animator>().SetTrigger("Die");
        }
    }
}
