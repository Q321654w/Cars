using Features;
using Features.Cars;

namespace DefaultNamespace.Features
{
    public class PlayerBuilder
    {
        private readonly CarConfig _config;
        private readonly PlayerDriverFactory _playerDriverFactory;
        private readonly CarFactory _carFactory;

        private readonly string _playerId;

        public PlayerBuilder(PlayerDriverFactory playerDriverFactory, CarFactory carFactory, string playerId,
            CarConfig config)
        {
            _playerDriverFactory = playerDriverFactory;
            _carFactory = carFactory;

            _playerId = playerId;
            _config = config;
        }

        public Driver BuildPlayer()
        {
            Driver driver = null;

            var car = _carFactory.Create(_config);
            if (_playerDriverFactory.CanCreate(_playerId))
                driver = _playerDriverFactory.Create(_playerId, car);

            return driver;
        }
    }
}