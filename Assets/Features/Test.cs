using System.Collections.Generic;
using Features.Cars;
using Features.Cars.CarBuilders;
using Features.Cars.Engines;
using Features.GameUpdate;
using Features.Maps;
using UnityEngine;

namespace Features
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Map _map;
        [SerializeField] private int _winLoopCount;
        [SerializeField] private GameUpdates _updates;
        [SerializeField] private EngineFactory _engineFactory;
        [SerializeField] private CarConfig[] _configs;
        [SerializeField] private string _carId;
        
        private void Start()
        {
            var directionProviderFactory = new PathProviderFactory(_map.VertexPath);
            var carFactory = new CarFactory(_configs, _engineFactory, directionProviderFactory);

            var player = carFactory.Create(_carId);
            var cars = new List<Car>() {player};
            var level = new Level(_map, _winLoopCount, cars, _updates);
            level.Start(cars);
        }
        
    }
}