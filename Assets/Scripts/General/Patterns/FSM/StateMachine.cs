namespace General.Patterns.FSM
{
    public class StateMachine
    {
        public Patterns.FSM.State CurrentState { get; private set; }

        public void Initialize(Patterns.FSM.State startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(Patterns.FSM.State newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}