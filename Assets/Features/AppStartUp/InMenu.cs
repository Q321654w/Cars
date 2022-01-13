namespace DefaultNamespace
{
    public class InMenu : IGameState
    {
        private Settings _settings;

        public InMenu(Settings settings)
        {
            _settings = settings;
        }
        
        public  void Enter()
        {
            throw new System.NotImplementedException();
        }

        public  void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}