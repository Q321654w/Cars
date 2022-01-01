using System.Linq;
using Features.Cars.Engines;
using Features.IDirectionProviders;
using PathCreation;
using UnityEngine;

namespace Features.Cars.CarBuilders
{
    public class CarFactory
    {
        private readonly CarConfig[] _configs;
        private readonly EngineFactory _engineFactory;
        private readonly DirectionProviderFactory _directionProviderFactory;

        public CarFactory(CarConfig[] configs, EngineFactory engineFactory, DirectionProviderFactory directionProviderFactory)
        {
            _configs = configs;
            _engineFactory = engineFactory;
            _directionProviderFactory = directionProviderFactory;
        }

        public Car Create(string id)
        {
            var config = _configs.Single(s => s.Id == id);
            var instance = Object.Instantiate(config.CarPrefab);
            var rigidbody = instance.GetComponent<Rigidbody>();
            var engine = _engineFactory.Create(config.EngineId, rigidbody);
            instance.Initialize(engine);
            return instance;
        }
    }

    public class DirectionProviderFactory
    {
        private readonly VertexPath _vertexPath;

        public DirectionProviderFactory(VertexPath vertexPath)
        {
            _vertexPath = vertexPath;
        }

        public IDirectionProvider Create(string id, Transform car)
        {
            return new PathDirectionProvider(car, _vertexPath, 0.1f);
        }
    }
}