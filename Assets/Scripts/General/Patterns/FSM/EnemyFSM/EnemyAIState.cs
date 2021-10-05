using Enemy;

namespace General.Patterns.FSM.EnemyFSM
{
    public abstract class EnemyAIState : State
    {
        protected readonly EnemyAI EnemyAI;

        protected EnemyAIState(EnemyAI enemyAI)
        {
            EnemyAI = enemyAI;
        }
    }
}