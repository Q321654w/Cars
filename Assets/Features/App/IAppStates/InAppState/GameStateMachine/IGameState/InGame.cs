using System;
using System.Collections.Generic;
using Features;
using Features.Cars;
using Features.GameUpdate;

namespace DefaultNamespace
{
    public class InGame : IGameState, IScoreBoardProvider
    {
        public event Action<Queue<Car>> Created;
        
        private readonly InGameView _view;
        private readonly IStateSwitcher _stateSwitcher;
        private GameUpdates _gameUpdates;
        private Level _level;

        public InGame(WindowFactory windowFactory, ILevelProvider levelProvider, IGameUpdatesProvider gameUpdatesProvider,
            IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
            _view = windowFactory.CreateInGameView();
            levelProvider.Loaded += OnLoaded;
            gameUpdatesProvider.Instanced += OnInstanced;
        }

        private void OnInstanced(GameUpdates gameUpdates)
        {
            _gameUpdates = gameUpdates;
        }

        private void OnLoaded(Level level)
        {
            _level = level;
        }

        public void Enter()
        {
            _level.Completed += OnCompleted;
            _gameUpdates.AddToUpdateList(_level);
            _gameUpdates.ResumeUpdate();
        }

        private void OnCompleted(Queue<Car> scoreBoard)
        {
            _stateSwitcher.SwitchState<EndGame>();
        }
    }
}