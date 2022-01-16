using Features;
using Features.Cars;

namespace DefaultNamespace.Features
{
    public class PlayerBuilder
    {
        private readonly CarConfig _config;
        private readonly PlayerDriverFactory _playerDriverFactory;
        private readonly CarFactory _carFactory;

        public PlayerBuilder(PlayerDriverFactory playerDriverFactory, CarFactory carFactory,
            CarConfig config)
        {
            _playerDriverFactory = playerDriverFactory;
            _carFactory = carFactory;

            _config = config;
        }

        public Driver BuildPlayer()
        {
            var car = _carFactory.Create(_config);
            var driver = _playerDriverFactory.Create(Constants.PLAYER_ID, car);

            return driver;
        }
    }
}