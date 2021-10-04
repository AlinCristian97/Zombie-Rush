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
            
            if (EnemyAI.IsProvoked)
            {
                EnemyAI.StateMachine.ChangeState(EnemyAI.States.ChaseState);
            }
        }
    }
}