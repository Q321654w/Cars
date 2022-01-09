﻿using System.Linq;
using DefaultNamespace.Features;
using Features.Cars.Engines;
using Features.Cars.Engines.Configs;
using UnityEngine;

namespace Features.Cars
{
    [CreateAssetMenu(menuName = "CarFactory")]
    public class CarFactory : ScriptableObject
    {
        [SerializeField] private CarConfig[] _configs;
        [SerializeField] private EngineFactory _engineFactory;

        public Car Create(int id)
        {
            var config = _configs.Single(s => s.Id == id);

            var instance = Object.Instantiate(config.CarPrefab);
            var wheels = instance.Wheels;

            var frontRightWheel = wheels.Single(s => s.Position == WheelPosition.FrontRight);
            var frontLeftWheel = wheels.Single(s => s.Position == WheelPosition.FrontLeft);

            var engine = _engineFactory.Create(config.EngineId, frontRightWheel, frontLeftWheel);
            instance.Initialize(engine);

            return instance;
        }

        public Car Create(Car prefab, EngineConfig config)
        {
            var instance = Object.Instantiate(prefab);
            var wheels = instance.Wheels;

            var frontRightWheel = wheels.Single(s => s.Position == WheelPosition.FrontRight);
            var frontLeftWheel = wheels.Single(s => s.Position == WheelPosition.FrontLeft);

            var engine = _engineFactory.Create(config, frontRightWheel, frontLeftWheel);
            instance.Initialize(engine);

            return instance;
        }
    }
}