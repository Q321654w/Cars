using System;

namespace DefaultNamespace
{
    public class InApp : IAppState
    {
        public event Action Ended;

        private readonly AppInfoContainer _appInfoContainer;
        private GameStateMachine _gameStateMachine;

        public InApp(AppInfoContainer appInfoContainer)
        {
            _appInfoContainer = appInfoContainer;
        }

        public void Enter()
        {
            var assetDataBase = _appInfoContainer.AssetDataBase;
            var windowFactory = new WindowFactory(assetDataBase);
            _gameStateMachine = new GameStateMachine(windowFactory, _appInfoContainer);
            _gameStateMachine.Start();
        }
    }
}