using System;
using Features;
using Features.Cars;
using Features.GameUpdate;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    public class LoadGame : IGameState, ILevelProvider, IGameUpdatesProvider
    {
        public event Action<GameUpdates> Instanced;
        public event Action<Level> Loaded;

        private readonly AppInfoContainer _appInfo;
        private readonly AssetDataBase _assetDataBase;
        private readonly LoadGameView _view;
        private readonly IStateSwitcher _stateSwitcher;
        private LevelConfig _config;

        public LoadGame(WindowFactory windowFactory, ILevelConfigProvider levelConfigProvider, AppInfoContainer appInfo,
            IStateSwitcher stateSwitcher)
        {
            _appInfo = appInfo;
            _stateSwitcher = stateSwitcher;
            _assetDataBase = appInfo.AssetDataBase;

            _view = windowFactory.CreateLoadGameView();
            levelConfigProvider.ConfigSelected += OnConfigSelected;
        }

        private void OnConfigSelected(LevelConfig config)
        {
            _config = config;
        }

        public void Enter()
        {
            _view.Show();

            var playerFactory = _assetDataBase.GetAsset<PlayerDriverFactory>(Constants.PLAYER_DRIVER_FACTORY_ID);
            var carFactory = _assetDataBase.GetAsset<CarFactory>(Constants.CAR_FACTORY_ID);

            var mapBuilder = new MapBuilder();
            var driverFactories = new IDriverFactory[]
            {
                playerFactory,
                new AiDriverFactory(_appInfo.GameInfoContainer.Treshold, mapBuilder),
            };
            var driverFactory = new DriverFactoryFacade(driverFactories);

            var camera = _appInfo.GameInfoContainer.Camera;
            var levelLoader = new LevelLoader(mapBuilder, carFactory, driverFactory, _config.PlayerConfig, camera);

            var level = levelLoader.Load(_config);
            Loaded?.Invoke(level);

            var gameUpdatesPrefab = _assetDataBase.GetAsset<GameUpdates>(Constants.GAME_UPDATES_ID);
            var gameUpdates = Object.Instantiate(gameUpdatesPrefab);
            Instanced?.Invoke(gameUpdates);

            _stateSwitcher.SwitchState<InGame>();
            _view.Hide();
        }
    }
}