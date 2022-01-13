using System;

namespace DefaultNamespace
{
    public class LoadApp : IAppState
    {
        public event Action Ended;
        
        private readonly AppInfoContainer _appInfoContainer;
        
        public LoadApp(AppInfoContainer appInfoContainer)
        {
            _appInfoContainer = appInfoContainer;
        }
        
        public void Enter()
        {
            _appInfoContainer.GameInfoContainer.AssetDataBase = new AssetDataBase();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}