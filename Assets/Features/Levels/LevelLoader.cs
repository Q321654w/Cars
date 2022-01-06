using System.Collections.Generic;
using DefaultNamespace.Features;
using Features.Cars;

namespace Features
{
    public class LevelLoader
    {
        private readonly PlayerBuilder _playerBuilder;
        private readonly CarFactory _carFactory;
        private readonly MapBuilder _mapBuilder;
        private readonly DriverFactoryFacade _driverFactory;

        public LevelLoader(MapBuilder mapBuilder, CarFactory carFactory, DriverFactoryFacade driverFactory, PlayerBuilder playerBuilder)
        {
            _mapBuilder = mapBuilder;
            _carFactory = carFactory;
            _driverFactory = driverFactory;
            _playerBuilder = playerBuilder;
        }

        public Level Load(LevelConfig config)
        {
            var map = _mapBuilder.Build(config.MapPrefab);
            var length = map.BotMarkers.Length;
            var drivers = new List<Driver>(length + 1);

            for (var index = 0; index < length; index++)
            {
                var carMarker = map.BotMarkers[index];
                var car = _carFactory.Create(carMarker.CarId);
                carMarker.MoToMe(car.transform);
                
                var driver = _driverFactory.Create(config.DriverIds[index], car);

                drivers.Add(driver);
            }

            var player = _playerBuilder.BuildPlayer();
            map.PlayerMarker.MoToMe(player.ControledCar.transform);
            drivers.Add(player);

            var level = new Level(map, config.Loops, drivers);
            return level;
        }
    }
}