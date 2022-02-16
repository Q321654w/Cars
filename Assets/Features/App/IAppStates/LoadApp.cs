using System;
using UnityEngine;
using Object = UnityEngine.Object;

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
            _appInfoContainer.GameInfoContainer = new GameInfoContainer
            {
                Treshold = 10F, LevelConfigs = assetDataBase.GetAsset<LevelConfigs>(Constants.LEVEL_CONFIGS_ID).AllConfigs
            };
            var cameraPrefab = assetDataBase.GetAsset<Camera>(Constants.CAMERA_ID);
            _appInfoContainer.GameInfoContainer.Camera = Object.Instantiate(cameraPrefab);
            Ended?.Invoke();
        }
    }
}