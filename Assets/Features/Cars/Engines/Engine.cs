using DefaultNamespace.Features;
using Features.Cars.Engines.Stats;
using UnityEngine;

namespace Features.Cars.Engines
{
    public class Engine
    {
        private readonly PIDRegulator _rotateRegulator;
        private readonly Wheel _firstWheel;
        private readonly Wheel _secondWheel;
        private readonly EngineStats _stats;

        private float _speed;

        public Engine(EngineStats stats, PIDRegulator rotateRegulator, Wheel firstWheel, Wheel secondWheel)
        {
            _stats = stats;
            _firstWheel = firstWheel;
            _rotateRegulator = rotateRegulator;
            _secondWheel = secondWheel;
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
            _firstWheel.AddTorque(smoothedForce);
        }

        public void Rotate(float deltaTime, float xDirection)
        {
            var transform = _firstWheel.transform;
            var right = transform.right;
            var direction = right;
            var error = Vector3.Dot(direction, right);
            var angle = _rotateRegulator.Calculate(error, deltaTime) * _stats.TurningSpeed * xDirection;
            _firstWheel.AddSteerAngle(angle);
            _secondWheel.AddSteerAngle(angle);
        }
    }
}