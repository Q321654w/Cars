using System.Collections.Generic;
using Features.Cars;

namespace Features
{
    public class LevelLoader
    {
        private readonly CarFactory _carFactory;
        private readonly MapBuilder _mapBuilder;
        private readonly IDriverFactory _driverFactory;

        public LevelLoader(MapBuilder mapBuilder, CarFactory carFactory, IDriverFactory driverFactory)
        {
            _mapBuilder = mapBuilder;
            _carFactory = carFactory;
            _driverFactory = driverFactory;
        }

        public Level Load(LevelConfig config)
        {
            var map = _mapBuilder.Build(config.MapPrefab);
            var length = map.CarMarkers.Length;
            var cars = new Dictionary<Car, Driver>();

            for (var index = 0; index < length; index++)
            {
                var carMarker = map.CarMarkers[index];
                var car = _carFactory.Create(carMarker.CarId);
                carMarker.MoToMe(car.transform);
                
                var driver = _driverFactory.Create(config.DriverIds[index], car);
                
                cars.Add(car, driver);
            }

            var level = new Level(map, config.Loops, cars);
            return level;
        }
    }
}