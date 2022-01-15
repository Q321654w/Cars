using System;

namespace DefaultNamespace
{
    public class InApp : IAppState
    {
        public event Action Ended;

        private readonly AppInfoContainer _appInfoContainer;
        //private GameStateMachine _gameStateMachine;

        public InApp(AppInfoContainer appInfoContainer)
        {
            _appInfoContainer = appInfoContainer;
            var assetDataBase = new AssetDataBase();

            var windowFactory = new WindowFactory(assetDataBase);
            var menuWindow = windowFactory.CreateWindow(WindowType.MainMenu);
            var inMenu = new InMenu(menuWindow);
            var loadGame = new LoadGame();
            var inGame = new InGame();
            var pause = new Pause();
            var endGame = new EndGame();

            var _gameStateMachine = new GameStateMachine(inMenu);
            var loadGameTransition = new Transition(loadGame, _gameStateMachine);
            var mainMenuPresenter = new MainMenuPresenter(menuWindow, loadGameTransition);

            _gameStateMachine.Start();
        }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}