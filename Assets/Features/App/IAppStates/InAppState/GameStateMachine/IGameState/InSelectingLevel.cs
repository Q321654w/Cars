using System;
using Features;

namespace DefaultNamespace
{
    public class InSelectingLevel : IGameState, ILevelConfigProvider
    {
        public event Action<LevelConfig> ConfigSelected;

        private readonly IStateSwitcher _stateSwitcher;
        private readonly InSelectingLevelView _view;

        private LevelConfig _levelConfig;

        public InSelectingLevel(WindowFactory windowFactory, AssetDataBase assetDataBase, IStateSwitcher stateSwitcher)
        {
            _view = windowFactory.CreateSelectingView();

            var levelConfigs = assetDataBase.GetAsset<LevelConfigs>(Constants.LEVEL_CONFIGS_ID);
            _view.Initialize(levelConfigs.AllConfigs, assetDataBase);
            _view.ConfigSelected += OnConfigSelected;

            _stateSwitcher = stateSwitcher;
        }

        private void OnConfigSelected(LevelConfig config)
        {
            _levelConfig = config;
            ConfigSelected?.Invoke(_levelConfig);
            _stateSwitcher.SwitchState<LoadGame>();
            _view.Hide();
        }

        public void Enter()
        {
            _view.Show();
        }
    }
}