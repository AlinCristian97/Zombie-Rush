using Enemy;
using UnityEngine;

namespace General.Patterns.FSM.EnemyFSM.States
{
    public class EnemyAIAttackState : EnemyAIState
    {
        public EnemyAIAttackState(EnemyAI enemyAI) : base(enemyAI)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enemy Attack State: Enter");
        }

        public override void Exit()
        {
            Debug.Log("Enemy Attack State: Exit");
        }

        public override void Execute()
        {
            Debug.Log("Enemy Attack State: Execute");

            EnemyAI.FaceTarget();

            if (EnemyAI.AttackCooldownPassed())
            {
                EnemyAI.UpdateNextAttackTime();
                EnemyAI.TriggerAttackAnimation();
            }
            
            if (!EnemyAI.TargetInRange)
            {
                EnemyAI.StateMachine.ChangeState(EnemyAI.States.ChaseState);
            }
        }
    }
}