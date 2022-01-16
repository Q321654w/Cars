using System;
using DefaultNamespace.Features;
using Features;
using Features.Cars;
using Features.GameUpdate;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    public class LoadGame : IGameState, ILevelProvider, IGameUpdatesProvider
    {
        public event Action Entered;
        public event Action Ended;

        public event Action<GameUpdates> Instanced;
        public event Action<Level> Loaded;

        private readonly GameInfoContainer _gameInfo;
        private readonly AssetDataBase _assetDataBase;
        private LevelConfig _config;

        public LoadGame(ILevelConfigProvider levelConfigProvider, GameInfoContainer gameInfo, AssetDataBase assetDataBase)
        {
            levelConfigProvider.ConfigSelected += OnConfigSelected;
            _gameInfo = gameInfo;
            _assetDataBase = assetDataBase;
        }

        private void OnConfigSelected(LevelConfig config)
        {
            _config = config;
        }

        public void Enter()
        {
            Entered?.Invoke();

            var playerFactory = _assetDataBase.GetAsset<PlayerDriverFactory>(Constants.PLAYER_DRIVER_FACTORY_ID);
            var carFactory = _assetDataBase.GetAsset<CarFactory>(Constants.CAR_FACTORY_ID);

            var mapBuilder = new MapBuilder();
            var driverFactories = new IDriverFactory[]
            {
                playerFactory,
                new AiDriverFactory(_gameInfo.Treshold, mapBuilder),
            };
            var driverFactory = new DriverFactoryFacade(driverFactories);
            var playerBuilder = new PlayerBuilder(playerFactory, carFactory, _config.PlayerConfig);

            var levelLoader = new LevelLoader(mapBuilder, carFactory, driverFactory, playerBuilder);

            var level = levelLoader.Load(_config);
            Loaded?.Invoke(level);

            var gameUpdatesPrefab = _assetDataBase.GetAsset<GameUpdates>(Constants.GAME_UPDATES_ID);
            var gameUpdates = Object.Instantiate(gameUpdatesPrefab);
            Instanced?.Invoke(gameUpdates);
        }

        public void Exit()
        {
            Ended?.Invoke();
        }
    }
}