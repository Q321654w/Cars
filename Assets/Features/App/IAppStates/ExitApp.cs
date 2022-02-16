using System;

namespace DefaultNamespace
{
    public class ExitApp : IAppState
    {
        public event Action Ended;

        private readonly AppInfoContainer _appInfoContainer;
        private readonly Action _quit;
        
        public ExitApp(AppInfoContainer appInfoContainer, Action quit)
        {
            _appInfoContainer = appInfoContainer;
            _quit = quit;
        }

        public void Enter()
        {
            _quit.Invoke();
        }
    }
}