using System.Collections.Generic;
using DefaultNamespace;
using Features.Cars;
using UnityEngine;

namespace Features
{
    public class LevelLoader
    {
        private readonly CarFactory _carFactory;
        private readonly MapBuilder _mapBuilder;
        private readonly DriverFactoryFacade _driverFactory;
        private readonly CarConfig _config;
        private readonly Camera _camera;

        public LevelLoader(MapBuilder mapBuilder, CarFactory carFactory, DriverFactoryFacade driverFactory, CarConfig config, Camera camera)
        {
            _mapBuilder = mapBuilder;
            _carFactory = carFactory;
            _driverFactory = driverFactory;
            _config = config;
            _camera = camera;
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
                carMarker.MoveToMe(car.transform);

                var driver = _driverFactory.Create(config.DriverIds[index], car);

                drivers.Add(driver);
            }

            var playerCar = _carFactory.Create(_config);
            _camera.transform.SetParent(playerCar.transform);
            _camera.transform.localPosition = new Vector3(0,2,-5);
            var player = _driverFactory.Create(Constants.PLAYER_ID, playerCar);

            map.PlayerMarker.MoveToMe(player.ControledCar.transform);
            drivers.Add(player);

            var level = new Level(map, config.Loops, drivers);
            return level;
        }
    }
}