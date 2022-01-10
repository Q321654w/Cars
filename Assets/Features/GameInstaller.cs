using Features;
using Features.Cars;
using Features.GameUpdate;
using UnityEngine;

namespace DefaultNamespace.Features
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private CarFactory _carFactory;
        [SerializeField] private PlayerDriverFactory _playerFactory;
        [SerializeField] private string _aiIdContext;
        [SerializeField] private float _threshold;
        [SerializeField] private LevelConfig _config;
        [SerializeField] private GameUpdates _updates;

        [Space(10)] [Header("Player Parametrs")] [SerializeField]
        private string _playerId;

        [SerializeField] private CarConfig _carConfig;

        private void Start()
        {
            var mapBuilder = new MapBuilder();
            var driverFactories = new IDriverFactory[]
            {
                _playerFactory,
                new AiDriverFactory(_aiIdContext, _threshold, mapBuilder),
            };
            var driverFactory = new DriverFactoryFacade(driverFactories);
            var playerBuilder = new PlayerBuilder(_playerFactory, _carFactory, _playerId, _carConfig);
            var levelLoader = new LevelLoader(mapBuilder, _carFactory, driverFactory, playerBuilder);
            var level = levelLoader.Load(_config);
            _updates.AddToUpdateList(level);
            _updates.ResumeUpdate();
        }
    }
}