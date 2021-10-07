using Enemy;
using UnityEngine;

namespace General.Patterns.FSM.EnemyFSM.States
{
    public class EnemyAIDeadState : EnemyAIState
    {
        public EnemyAIDeadState(EnemyAI enemyAI) : base(enemyAI)
        {
        }

        public override void Enter()
        {
            EnemyAI.enabled = false;
            EnemyAI.Collider.enabled = false;
            EnemyAI.NavMeshAgent.enabled = false;
            EnemyAI.ClearProvoked();
            EnemyAI.Animator.SetTrigger("Die");
            // Debug.Log("Enemy Dead State: Enter");
        }

        public override void Exit()
        {
            // Debug.Log("Enemy Dead State: Exit");
        }

        public override void Execute()
        {
            // Debug.Log("Enemy Dead State: Execute");
        }
    }
}