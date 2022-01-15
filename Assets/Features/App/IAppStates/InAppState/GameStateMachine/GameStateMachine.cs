namespace DefaultNamespace
{
    public class GameStateMachine : IStateSwitcher
    {
        private IGameState _currentState;

        public GameStateMachine(IGameState currentState)
        {
            _currentState = currentState;
        }

        public void Start()
        {
            EnterInState();
        }
        
        public void SwitchState(IGameState state)
        {
            ExitFromState();

            _currentState = state;

            EnterInState();
        }
        
        private void ExitFromState()
        {
            _currentState.Exit();
        }

        private void EnterInState()
        {
            _currentState.Enter();
        }
    }
}