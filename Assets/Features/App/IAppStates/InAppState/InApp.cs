using System;

namespace DefaultNamespace
{
    public class InApp : IAppState
    {
        public event Action Ended;

        private readonly AppInfoContainer _appInfoContainer;
        private readonly GameStateMachine _gameStateMachine;
        private MainMenuPresenter _presenter;

        public InApp(AppInfoContainer appInfoContainer)
        {
            _appInfoContainer = appInfoContainer;
            var assetDataBase = new AssetDataBase();

            var windowFactory = new WindowFactory(assetDataBase);
            var inMenu = new InMenu();
            var loadGame = new LoadGame();
            var inGame = new InGame();
            var pause = new Pause();
            var endGame = new EndGame();

            _gameStateMachine = new GameStateMachine(inMenu);
            var loadGameTransition = new Transition(loadGame, _gameStateMachine);
            _presenter = new MainMenuPresenter(windowFactory, inMenu, loadGameTransition);
        }

        public void Enter()
        {
            _gameStateMachine.Start();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}