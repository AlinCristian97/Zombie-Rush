using Enemy;
using UnityEngine;

namespace General.Patterns.FSM.EnemyFSM.States
{
    public class EnemyAIPatrolState : EnemyAIState
    {
        public EnemyAIPatrolState(EnemyAI enemyAI) : base(enemyAI)
        {
        }

        public override void Enter()
        {
            EnemyAI.Animator.SetBool("IsWalking", true);
            EnemyAI.NavMeshAgent.SetDestination(EnemyAI.PatrolPointA);
            EnemyAI.NavMeshAgent.speed = EnemyAI.PatrolSpeed;
            
            Debug.Log("Enemy Patrol State: Enter");
        }

        public override void Exit()
        {
            EnemyAI.Animator.SetBool("IsWalking", false);
            Debug.Log("Enemy Patrol State: Exit");
        }

        public override void Execute()
        {
            Debug.Log("Enemy Patrol State: Execute");
            
            if (Mathf.Abs(EnemyAI.transform.position.x - EnemyAI.PatrolPointA.x) < 10f ||
                Mathf.Abs(EnemyAI.transform.position.z - EnemyAI.PatrolPointA.z) < 10f)
            {
                EnemyAI.NavMeshAgent.SetDestination(EnemyAI.PatrolPointB);
            } 
            else if (Mathf.Abs(EnemyAI.transform.position.x - EnemyAI.PatrolPointB.x) < 10f ||
                    Mathf.Abs(EnemyAI.transform.position.z - EnemyAI.PatrolPointB.z) < 10f)
            {
                EnemyAI.NavMeshAgent.SetDestination(EnemyAI.PatrolPointA);
            }
            
            if (EnemyAI.IsProvoked)
            {
                EnemyAI.StateMachine.ChangeState(EnemyAI.States.ChaseState);
            }
        }
    }
}