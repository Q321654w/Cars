using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Features;
using Features.Cars.Engines.Stats;
using UnityEngine;

namespace Features.Cars.Engines
{
    public class Engine
    {
        private readonly PIDRegulator _rotateRegulator;
        private readonly Wheel[] _moveWheels;
        private readonly Wheel[] _rotateWheels;
        private readonly EngineStats _stats;

        private float _speed;

        public Engine(EngineStats stats, PIDRegulator rotateRegulator, IEnumerable<Wheel> moveWheels, IEnumerable<Wheel> rotatingWheels)
        {
            _stats = stats;
            _rotateRegulator = rotateRegulator;
            _moveWheels = moveWheels.ToArray();
            _rotateWheels = rotatingWheels.ToArray();
        }

        public void Accelerate()
        {
            var acceleration = _stats.AccelerationSpeed;
            _speed = Mathf.Clamp(_speed + acceleration, -_stats.MaxSpeed, _stats.MaxSpeed);
        }

        public void Slowdown()
        {
            var acceleration = _stats.BrakingSpeed;
            _speed = Mathf.Clamp(_speed - acceleration, -_stats.MaxSpeed, _stats.MaxSpeed);
        }

        public void Move(float deltaTime)
        {
            var force = _speed;
            var smoothedForce = force * deltaTime;
            
            foreach (var wheel in _moveWheels)
            {
                wheel.SetTorque(smoothedForce);
            }
        }

        public void Rotate(float deltaTime, float deltaAngle)
        {
            var clampedAngle = Mathf.Clamp(deltaAngle, -_stats.TurningSpeed, _stats.TurningSpeed);

            foreach (var wheel in _rotateWheels)
            {
                wheel.AddSteerAngle(clampedAngle);
            }
        }

        public void Brake()
        {
            foreach (var wheel in _moveWheels)
            {
                wheel.SetBrake(_speed);
            }
        }
    }
}