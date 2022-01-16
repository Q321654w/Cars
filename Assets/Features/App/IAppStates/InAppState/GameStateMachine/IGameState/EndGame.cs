using Features;

namespace DefaultNamespace
{
    public class EndGame : IGameState
    {
        private Level _level;

        public EndGame(ILevelProvider levelProvider)
        {
            levelProvider.Loaded += OnLoaded;
        }

        private void OnLoaded(Level level)
        {
            _level = level;
        }

        public void Enter()
        {
            _level.CleanUp();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}