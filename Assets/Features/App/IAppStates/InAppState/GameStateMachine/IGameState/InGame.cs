using Features;
using Features.GameUpdate;

namespace DefaultNamespace
{
    public class InGame : IGameState
    {
        private GameUpdates _gameUpdates;
        private Level _level;
        private AssetDataBase _assetDataBase;

        public InGame(ILevelProvider levelProvider,IGameUpdatesProvider gameUpdatesProvider)
        {
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
            _gameUpdates.AddToUpdateList(_level);
            _gameUpdates.ResumeUpdate();
        }

        public void Exit()
        {
            
        }
    }
}