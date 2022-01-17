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
            var assetDataBase = new AssetDataBase();
            _appInfoContainer.AssetDataBase = assetDataBase;
            _appInfoContainer.GameInfoContainer.Treshold = 10F;
            _appInfoContainer.GameInfoContainer.LevelConfigs = assetDataBase.GetAsset<LevelConfigs>(Constants.LEVEL_CONFIGS).AllConfigs;
            Ended?.Invoke();
        }

        public void Exit()
        {
            
        }
    }
}