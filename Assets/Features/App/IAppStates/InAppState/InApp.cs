using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class InApp : IAppState
    {
        public event Action Ended;

        private readonly AppInfoContainer _appInfoContainer;
        private readonly GameStateMachine _gameStateMachine;
        private MainMenuPresenter _presenter;

        private List<Transition> _transitions;

        public InApp(AppInfoContainer appInfoContainer)
        {
            _appInfoContainer = appInfoContainer;
            var assetDataBase = new AssetDataBase();

            var windowFactory = new WindowFactory(assetDataBase);
            var inMenu = new InMenu();
            var inSelectingLevel = new InSelectingLevel();
            var loadGame = new LoadGame(inSelectingLevel, _appInfoContainer.GameInfoContainer, assetDataBase);
            var inGame = new InGame(loadGame, loadGame);
            var pause = new Pause(loadGame);
            var endGame = new EndGame(loadGame);

            var states = new List<IGameState>()
            {
                inMenu, inSelectingLevel, loadGame, inGame, pause, endGame
            };

            _gameStateMachine = new GameStateMachine(inMenu, states);
            var menuTransition = new Transition(inSelectingLevel, _gameStateMachine);
            var levelSelectingTransition = new Transition(loadGame, _gameStateMachine);
            var loadGameTransition = new Transition(inGame, _gameStateMachine);
            var inGameTransition = new Transition(pause, _gameStateMachine);
            var pauseTransition = new Transition(inGame, _gameStateMachine);

            _transitions = new List<Transition>()
            {
                menuTransition,
                levelSelectingTransition,
                loadGameTransition,
                inGameTransition, 
                pauseTransition,
            };
            _presenter = new MainMenuPresenter(windowFactory, inMenu, menuTransition);
        }

        public void Enter()
        {
            _gameStateMachine.Start();
        }

        public void Exit()
        {
            
        }
    }
}