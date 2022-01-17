using System.Collections.Generic;

namespace DefaultNamespace
{
    public class GameStateMachine : IStateSwitcher
    {
        private readonly List<IGameState> _states;
        private IGameState _currentState;

        public GameStateMachine(WindowFactory windowFactory, AppInfoContainer appInfoContainer)
        {
            var inMenu = new InMenu(windowFactory, this);
            var inSelectingLevel = new InSelectingLevel(windowFactory, appInfoContainer.AssetDataBase, this);
            var loadGame = new LoadGame(windowFactory, inSelectingLevel, appInfoContainer, this);
            var inGame = new InGame(windowFactory, loadGame, loadGame, this);
            var pause = new Pause(loadGame);
            var endGame = new EndGame(loadGame, inGame);

            _states = new List<IGameState>()
            {
                inMenu, inSelectingLevel, loadGame, inGame, pause, endGame
            };

            _currentState = inMenu;
        }

        public void Start()
        {
            EnterInState();
        }

        public void SwitchState<T>() where T : IGameState
        {
            ExitFromState();

            _currentState = _states.Find(s => s is T);

            EnterInState();
        }

        private void ExitFromState()
        {
            _currentState.Exit();
        }

        private void EnterInState()
        {
            _currentState.Enter();
        }
    }
}