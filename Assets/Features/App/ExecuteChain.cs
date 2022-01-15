using System.Collections.Generic;

namespace DefaultNamespace
{
    public class ExecuteChain
    {
        private readonly Queue<IAppState> _states;
        private IAppState _currentState;

        public ExecuteChain()
        {
            _states = new Queue<IAppState>();
        }

        public ExecuteChain Append(IAppState state)
        {
            _states.Enqueue(state);
            return this;
        }

        public ExecuteChain Run()
        {
            EnterInState();
            return this;
        }

        private void OnStateEnded()
        {
            ExitFromState();
            EnterInState();
        }
        
        private void EnterInState()
        {
            _currentState.Ended += OnStateEnded;
            _currentState.Enter();
        }

        private void ExitFromState()
        {
            _currentState = _states.Dequeue();
            _currentState.Ended -= OnStateEnded;
            _currentState.Exit();
        }
    }
}