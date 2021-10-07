using Enemy;
using UnityEngine;

namespace General.Patterns.FSM.EnemyFSM.States
{
    public class EnemyAIChaseState : EnemyAIState
    {
        public EnemyAIChaseState(EnemyAI enemyAI) : base(enemyAI)
        {
        }

        public override void Enter()
        {
            EnemyAI.Animator.SetBool("IsRunning", true);
            EnemyAI.NavMeshAgent.speed = EnemyAI.ChaseSpeed;
            // Debug.Log("Enemy Chase State: Enter");
        }

        public override void Exit()
        {
            EnemyAI.Animator.SetBool("IsRunning", false);
            // Debug.Log("Enemy Chase State: Exit");
        }

        public override void Execute()
        {
            // Debug.Log("Enemy Chase State: Execute");

            EnemyAI.FaceTarget();
            EnemyAI.ChaseTarget();

            if (EnemyAI.TargetInRange)
            {
                EnemyAI.StateMachine.ChangeState(EnemyAI.States.AttackState);
            }
        }
    }
}