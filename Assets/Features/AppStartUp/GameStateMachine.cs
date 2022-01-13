using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class GameStateMachine
    {
        private readonly Dictionary<IGameState, IEnumerable<Transition>> _states;

        private IGameState _currentState;

        public GameStateMachine(Dictionary<IGameState, IEnumerable<Transition>> states, IGameState currentState)
        {
            _states = states;
            _currentState = currentState;
        }

        public void Start()
        {
            foreach (var transition in _states[_currentState])
            {
                transition.SwitchStateRequested += OnSwitchStateRequested;
            }
            
            _currentState.Enter();
        }

        private void OnSwitchStateRequested(IGameState state)
        {
            foreach (var transition in _states[_currentState])
            {
                transition.SwitchStateRequested -= OnSwitchStateRequested;
            }
            _currentState.Exit();
            
            _currentState = state;
            
            foreach (var transition in _states[_currentState])
            {
                transition.SwitchStateRequested += OnSwitchStateRequested;
            }
            _currentState.Enter();
        }
    }
}