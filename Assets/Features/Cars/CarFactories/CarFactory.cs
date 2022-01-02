using System;
using System.Linq;
using Features.Cars.Engines;
using Object = UnityEngine.Object;

namespace Features.Cars.CarBuilders
{
    public class CarFactory
    {
        public event Action<Car> Instanced;

        private readonly CarConfig[] _configs;
        private readonly EngineFactory _engineFactory;
        private readonly PathProviderFactory _pathProviderFactory;

        public CarFactory(CarConfig[] configs, EngineFactory engineFactory, PathProviderFactory pathProviderFactory)
        {
            _configs = configs;
            _engineFactory = engineFactory;
            _pathProviderFactory = pathProviderFactory;
        }

        public Car Create(string id)
        {
            var config = _configs.Single(s => s.Id == id);

            var instance = Object.Instantiate(config.CarPrefab);
            Instanced?.Invoke(instance);

            var engine = _engineFactory.Create(config.EngineId);
            var directionProvider = _pathProviderFactory.Create(config.DirectionProviderId);
            instance.Initialize(engine, directionProvider);

            return instance;
        }
    }
}