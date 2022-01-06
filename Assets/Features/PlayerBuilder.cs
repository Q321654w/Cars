using Features;
using Features.Cars;
using Features.Cars.Engines.Configs;

namespace DefaultNamespace.Features
{
    public class PlayerBuilder
    {
        private Car _prefab;
        private PlayerDriverFactory _playerDriverFactory;
        private CarFactory _carFactory;
        private EngineConfig _config;

        private string _playerId;

        public PlayerBuilder(Car prefab, PlayerDriverFactory playerDriverFactory, CarFactory carFactory, string playerId,
            EngineConfig config)
        {
            _prefab = prefab;
            _playerDriverFactory = playerDriverFactory;
            _carFactory = carFactory;

            _playerId = playerId;
            _config = config;
        }

        public Driver BuildPlayer()
        {
            Driver driver = null;
            
            var car = _carFactory.Create(_prefab, _config);
            if (_playerDriverFactory.CanCreate(_playerId))
                driver = _playerDriverFactory.Create(_playerId, car);
            
            return driver;
        }
    }
}