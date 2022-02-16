using System.Collections.Generic;
using Features;
using Features.Cars;

namespace DefaultNamespace
{
    public class EndGame : IGameState
    {
        private Queue<Car> _scoreBoard;
        private Level _level;

        public EndGame(ILevelProvider levelProvider, IScoreBoardProvider scoreBoardProvider)
        {
            scoreBoardProvider.Created += OnCreated;
            levelProvider.Loaded += OnLoaded;
        }

        private void OnCreated(Queue<Car> scoreBoard)
        {
            _scoreBoard = scoreBoard;
        }

        private void OnLoaded(Level level)
        {
            _level = level;
        }

        public void Enter()
        {
            _level.CleanUp();
        }
    }
}