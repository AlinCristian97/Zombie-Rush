using System;
using General;
using General.Patterns.FSM;
using General.Patterns.FSM.EnemyFSM;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        #region FSM

        public StateMachine StateMachine { get; private set; }
        public EnemyAIStates States { get; private set; }


        #endregion

        #region Components

        public Animator Animator { get; private set; }
        public Collider Collider { get; private set; }

        #endregion
        
        [SerializeField] private float _damage = 40f;
        private Health _targetHealth;
        
        [SerializeField] protected float AttackCooldown = 0.5f;
        private float _nextAttackTime;
        
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private float _chaseRange = 5f;
        [SerializeField] float _turnSpeed = 5f;

        public bool IsProvoked { get; private set; }
        
        private Health _health;

        public NavMeshAgent NavMeshAgent { get; private set; }
        private float _distanceToTarget = Mathf.Infinity;

        private void Awake()
        {
            #region FSM

            States = new EnemyAIStates(this);
            StateMachine = new StateMachine();

            #endregion

            #region Components

            Animator = GetComponent<Animator>();
            Collider = GetComponent<Collider>();
            _health = GetComponent<Health>();

            #endregion
            
        }

        private void OnEnable()
        {
            _health.OnDamageTaken += OnDamageTaken;
        }
        
        private void OnDisable()
        {
            _health.OnDamageTaken -= OnDamageTaken;
        }

        private void Start()
        {
            StateMachine.Initialize(States.IdleState);
            
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            StateMachine.CurrentState.Execute();
            
            if (_health.IsDead())
            {
                StateMachine.ChangeState(States.DeadState);
            }
        
            _distanceToTarget = Vector3.Distance(_targetTransform.position, transform.position);

            if (_distanceToTarget <= _chaseRange)
            {
                IsProvoked = true;
            }
        }
        
        public void UpdateNextAttackTime()
        {
            _nextAttackTime = Time.time + AttackCooldown;
        }

        public bool AttackCooldownPassed() => Time.time > _nextAttackTime;
    
        public void OnDamageTaken()
        {
            IsProvoked = true;
        }

        public void ClearProvoked()
        {
            IsProvoked = false;
        }

        public bool TargetInRange => _distanceToTarget < NavMeshAgent.stoppingDistance;

        public void ChaseTarget()
        {
            NavMeshAgent.SetDestination(_targetTransform.position);
        }
    
        public void AttackTarget()
        {
            Animator.SetTrigger("Attack");
        }

        #region Animator Trigger Events

        private void SetIdleState()
        {
            StateMachine.ChangeState(States.IdleState);
        }

        #endregion
    
        public void FaceTarget()
        {
            Vector3 direction = (_targetTransform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _chaseRange);
        }
    }
}
