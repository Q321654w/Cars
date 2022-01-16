using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class GameStateMachine : IStateSwitcher
    {
        private List<IGameState> _states;
        private IGameState _currentState;

        public GameStateMachine(IGameState currentState, IEnumerable<IGameState> states)
        {
            _currentState = currentState;
            _states = states.ToList();
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