using Features.GameUpdate;

namespace DefaultNamespace
{
    public class Pause : IGameState
    {
        private GameUpdates _gameUpdates;

        public Pause(IGameUpdatesProvider gameUpdatesProvider)
        {
            gameUpdatesProvider.Instanced += OnInstanced;
        }

        private void OnInstanced(GameUpdates gameUpdates)
        {
            _gameUpdates = gameUpdates;
        }

        public void Enter()
        {
            _gameUpdates.StopUpdate();
        }

        public void Exit()
        {
            _gameUpdates.ResumeUpdate();
        }
    }
}