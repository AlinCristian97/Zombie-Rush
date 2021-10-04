using Enemy;
using General.Patterns.FSM.EnemyFSM.States;

namespace General.Patterns.FSM.EnemyFSM
{
    public class EnemyAIStates
    {
        public EnemyAIState IdleState { get; }
        public EnemyAIState PatrolState { get; }
        public EnemyAIState AttackState { get; }
        public EnemyAIState DeadState { get; }
        public EnemyAIState ChaseState { get; }

        public EnemyAIStates(EnemyAI enemyAI)
        {
            IdleState = new EnemyAIIdleState(enemyAI);
            PatrolState = new EnemyAIPatrolState(enemyAI);
            AttackState = new EnemyAIAttackState(enemyAI);
            DeadState = new EnemyAIDeadState(enemyAI);
            ChaseState = new EnemyAIChaseState(enemyAI);
        }
    }
}