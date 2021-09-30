using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _damage = 40f;
        private Health _target;


        private void Start()
        {
            
        }

        public void AttackHitEvent()
        {

        }
    }
}