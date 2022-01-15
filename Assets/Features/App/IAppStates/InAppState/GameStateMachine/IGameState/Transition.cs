namespace DefaultNamespace
{
    public class Transition
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly IGameState _targetState;

        public Transition(IGameState targetState, IStateSwitcher stateSwitcher)
        {
            _targetState = targetState;
            _stateSwitcher = stateSwitcher;
        }

        public void GoToNextState()
        {
            _stateSwitcher.SwitchState(_targetState);
        }
    }
}