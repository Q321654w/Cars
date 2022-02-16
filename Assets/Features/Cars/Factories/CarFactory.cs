using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Features;
using Features.Cars.Engines;
using UnityEngine;

namespace Features.Cars
{
    [CreateAssetMenu(menuName = "CarFactory")]
    public class CarFactory : ScriptableObject
    {
        [SerializeField] private CarConfig[] _configs;
        [SerializeField] private EngineFactory _engineFactory;
        [SerializeField] private WheelFactory _wheelFactory;

        public Car Create(int id)
        {
            var config = _configs.Single(s => s.Id == id);

            return Create(config);
        }

        public Car Create(CarConfig config)
        {
            var instance = Instantiate(config.CarPrefab);

            var wheels = new List<Wheel>();

            foreach (var marker in instance.WheelMarkers)
            {
                var wheel = _wheelFactory.Create(marker);
                wheels.Add(wheel);
            }
            
            var engine = _engineFactory.Create(config.EngineId, wheels);
            instance.Initialize(engine, wheels);

            return instance;
        }
    }
}