using System.Collections.Generic;

namespace DefaultNamespace
{
    public class ExecuteChain
    {
        private readonly Queue<IAppState> _states;
        private IAppState _currentState;

        public ExecuteChain(Queue<IAppState> states)
        {
            _states = states;
        }

        public void Run()
        {
            EnterInState();
        }

        private void OnStateEnded()
        {
            ExitFromState();
            EnterInState();
        }
        
        private void EnterInState()
        {
            _currentState = _states.Dequeue();
            _currentState.Ended += OnStateEnded;
            _currentState.Enter();
        }

        private void ExitFromState()
        {
            _currentState.Ended -= OnStateEnded;
        }
    }
}