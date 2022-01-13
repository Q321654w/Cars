using System;

namespace DefaultNamespace
{
    public class ExitApp : IAppState
    {
        public event Action Ended;

        private readonly AppInfoContainer _appInfoContainer;
        private readonly Action _exit;
        
        public ExitApp(AppInfoContainer appInfoContainer, Action exit)
        {
            _appInfoContainer = appInfoContainer;
            _exit = exit;
        }

        public void Enter()
        {
            _exit.Invoke();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}