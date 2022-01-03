using System.Collections.Generic;
using Features.Cars;
using UnityEngine;

namespace Features
{
    public class LevelBuilder
    {
        private readonly CarFactoryBuilder _carFactoryBuilder;

        public LevelBuilder(CarFactoryBuilder carFactoryBuilder)
        {
            _carFactoryBuilder = carFactoryBuilder;
        }

        public Level Build(LevelConfig levelConfig)
        {
            var map = Object.Instantiate(levelConfig.MapPrefab);
            var carFactory = _carFactoryBuilder.Build();
            var cars = new List<Car>(map.MaxCarCount);

            for (int i = 0; i < map.CarMarkers.Length; i++)
            {
                var marker = map.CarMarkers[i];
                var car = carFactory.Create(marker.CarId);
                cars.Add(car);
                map.PlaceCar(car, i);
            }

            return new Level(map, levelConfig.Loops, cars);
        }
    }
}