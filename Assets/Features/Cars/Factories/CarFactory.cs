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

            var rotateWheels = new List<Wheel>();
            var moveWheels = new List<Wheel>();

            foreach (var marker in instance.WheelMarkers)
            {
                var wheel = _wheelFactory.Create(marker.Id, marker.transform, marker.IsRightWheel);

                if (marker.DoesTractionWork)
                    moveWheels.Add(wheel);

                if (marker.IsRotate)
                    rotateWheels.Add(wheel);
            }

            var wheels = new Wheel[rotateWheels.Count + moveWheels.Count];
            rotateWheels.CopyTo(wheels, 0);
            moveWheels.CopyTo(wheels, rotateWheels.Count);

            var engine = _engineFactory.Create(config.EngineId, rotateWheels, moveWheels);
            instance.Initialize(engine, wheels);

            return instance;
        }
    }
}