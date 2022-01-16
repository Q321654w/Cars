using System;

namespace DefaultNamespace
{
    public class InMenu : IGameState
    {
        public event Action Entered;
        public event Action Ended;

        public void Enter()
        {
            Entered?.Invoke();
        }

        public void Exit()
        {
            Ended?.Invoke();
        }
    }
}