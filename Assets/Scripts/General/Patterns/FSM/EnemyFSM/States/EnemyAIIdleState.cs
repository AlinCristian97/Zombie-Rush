using Enemy;
using UnityEngine;

namespace General.Patterns.FSM.EnemyFSM.States
{
    public class EnemyAIIdleState : EnemyAIState
    {
        public EnemyAIIdleState(EnemyAI enemyAI) : base(enemyAI)
        {
        }

        public override void Enter()
        {
            EnemyAI.Animator.SetBool("IsIdling", true);
            // Debug.Log("Enemy Idle State: Enter");
        }

        public override void Exit()
        {
            EnemyAI.Animator.SetBool("IsIdling", false);
            // Debug.Log("Enemy Idle State: Exit");
        }

        public override void Execute()
        {
            // Debug.Log("Enemy Idle State: Execute");
            
            if (EnemyAI.IsProvoked && !EnemyAI.TargetInRange)
            {
                EnemyAI.StateMachine.ChangeState(EnemyAI.States.ChaseState);
            }

            if (EnemyAI.TargetInRange && EnemyAI.AttackCooldownPassed())
            {
                EnemyAI.StateMachine.ChangeState(EnemyAI.States.AttackState);
            }

            if (!EnemyAI.TargetInRange)
            {
                EnemyAI.StateMachine.ChangeState(EnemyAI.States.PatrolState);
            }
        }
    }
}