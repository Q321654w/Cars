using System.Collections.Generic;
using DefaultNamespace;
using Features.Cars;
using Features.Maps;
using UnityEngine;

namespace Features
{
    public class LevelLoader
    {
        private readonly CarFactory _carFactory;
        private readonly MapBuilder _mapBuilder;
        private readonly DriverFactoryFacade _driverFactory;
        private readonly CarConfig _playerConfig;
        private readonly Camera _camera;

        public LevelLoader(MapBuilder mapBuilder, CarFactory carFactory, DriverFactoryFacade driverFactory,
            CarConfig playerConfig, Camera camera)
        {
            _mapBuilder = mapBuilder;
            _carFactory = carFactory;
            _driverFactory = driverFactory;
            _playerConfig = playerConfig;
            _camera = camera;
        }

        public Level Load(LevelConfig config)
        {
            var map = _mapBuilder.Build(config.MapPrefab);

            var drivers = CreateBots(map,config.DriverIds);

            var playerCar = CreatePlayerCar(map);
            var player = CreateDriver(playerCar, Constants.PLAYER_ID);

            drivers.Add(player);

            var level = new Level(map, config.Loops, drivers);
            return level;
        }

        private List<Driver> CreateBots(Map map, string[] driverIdes)
        {
            var drivers = new List<Driver>();
            var length = map.BotMarkers.Length;

            for (var index = 0; index < length; index++)
            {
                var carMarker = map.BotMarkers[index];
                var driverId = driverIdes[index];

                var car = CreateBotCar(carMarker);
                var driver = CreateDriver(car, driverId);

                drivers.Add(driver);
            }

            return drivers;
        }

        private Car CreatePlayerCar(Map map)
        {
            var playerCar = _carFactory.Create(_playerConfig);
            map.PlayerMarker.MoveToMe(playerCar.transform);

            _camera.transform.SetParent(playerCar.transform);
            _camera.transform.localPosition = new Vector3(0, 2, -5);

            return playerCar;
        }

        private Driver CreateDriver(Car car, string driverId)
        {
            var driver = _driverFactory.Create(driverId, car);
            return driver;
        }

        private Car CreateBotCar(BotCarMarker carMarker)
        {
            var car = _carFactory.Create(carMarker.CarId);
            carMarker.MoveToMe(car.transform);
            return car;
        }
    }
}