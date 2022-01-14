using System;

namespace DefaultNamespace
{
    public class Transition
    {
        public event Action<IGameState> SwitchStateRequested;
        
        private readonly IGameState _targetState;

        public Transition(IGameState targetState)
        {
            _targetState = targetState;
        }

        public void GoToNextState()
        {
            SwitchStateRequested?.Invoke(_targetState);
        }
    }
}