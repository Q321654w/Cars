using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class GameStateMachine
    {
        private readonly Dictionary<IGameState, List<Transition>> _states;

        private IGameState _currentState;

        public GameStateMachine(Dictionary<IGameState, IEnumerable<Transition>> states, IGameState currentState)
        {
            _states = new Dictionary<IGameState, List<Transition>>();

            foreach (var pair in states)
            {
                _states.Add(pair.Key, pair.Value.ToList());
            }

            _currentState = currentState;
        }

        public void Start()
        {
            EnterInState();
        }

        private void OnSwitchStateRequested(IGameState state)
        {
            ExitFromState();

            _currentState = state;

            EnterInState();
        }

        private void ExitFromState()
        {
            foreach (var transition in _states[_currentState])
            {
                transition.SwitchStateRequested -= OnSwitchStateRequested;
            }

            _currentState.Exit();
        }

        private void EnterInState()
        {
            foreach (var transition in _states[_currentState])
            {
                transition.SwitchStateRequested += OnSwitchStateRequested;
            }

            _currentState.Enter();
        }
    }
}