using System;

namespace DefaultNamespace
{
    public class Transition
    {
        public event Action<IGameState> SwitchStateRequested;
        
        private readonly IGameState _targetState;
        private readonly ITrigger _trigger;

        public Transition(IGameState targetState, ITrigger trigger)
        {
            _targetState = targetState;
            _trigger = trigger;
            _trigger.Triggered += OnTriggered;
        }

        private void OnTriggered()
        {
            _trigger.Triggered -= OnTriggered;
            SwitchStateRequested?.Invoke(_targetState);
        }
    }
}