using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class App
    {
        private readonly Queue<IAppState> _states;
        private IAppState _currentState;

        public App()
        {
            var appInfoContainer = new AppInfoContainer();

            var loadApp = new LoadApp(appInfoContainer);
            var inApp = new InApp(appInfoContainer);
            var exitApp = new ExitApp(appInfoContainer, Exit);

            _states = new Queue<IAppState>();

            _states.Enqueue(loadApp);
            _states.Enqueue(inApp);
            _states.Enqueue(exitApp);
        }

        public void Start()
        {
            _currentState = _states.Dequeue();
            _currentState.Ended += OnStateEnded;
            _currentState.Enter();
        }

        private void OnStateEnded()
        {
            _currentState.Ended -= OnStateEnded;
            _currentState.Exit();

            _currentState = _states.Dequeue();

            _currentState.Ended += OnStateEnded;
            _currentState.Enter();
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}