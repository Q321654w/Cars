using System;
using System.Collections.Generic;
using DefaultNamespace.Features;
using Features;
using UnityEngine;

namespace DefaultNamespace
{
    public class InSelectingLevelView : MonoBehaviour, IWindow
    {
        public event Action<LevelConfig> ConfigSelected;

        private AssetDataBase _assetDataBase;
        private Dictionary<int, LevelConfig> _configs;

        public InSelectingLevelView(AssetDataBase assetDataBase)
        {
            _assetDataBase = assetDataBase;
        }

        public void Initialize(LevelConfig[] levelConfigs, AssetDataBase assetDataBase)
        {
            _assetDataBase = assetDataBase;
            _configs = new Dictionary<int, LevelConfig>();

            var buttonPrefab = _assetDataBase.GetAsset<LevelConfigView>(Constants.LEVEL_CONFIG_VIEW_ID);
            
            for (int i = 0; i < levelConfigs.Length; i++)
            {
                var view = Instantiate(buttonPrefab, transform);
                view.Initialize(i);
                
                view.Selected += OnViewSelected;
                _configs.Add(i, levelConfigs[i]);
            }
        }

        private void OnViewSelected(int id)
        {
            var config = _configs[id];
            ConfigSelected?.Invoke(config);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}