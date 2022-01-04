using Features.Cars.Engines.Stats;
using UnityEngine;

namespace Features.Cars.Engines
{
    public class Engine
    {
        private readonly PIDRegulator _rotateRegulator;
        private readonly Rigidbody _rigidbody;
        private readonly EngineStats _stats;

        private float _speed;

        public Engine(EngineStats stats, Rigidbody rigidbody, PIDRegulator rotateRegulator)
        {
            _stats = stats;
            _rigidbody = rigidbody;
            _rotateRegulator = rotateRegulator;
        }

        public void Accelerate()
        {
            var acceleration =  _stats.AccelerationSpeed;
            _speed = Mathf.Clamp(_speed + acceleration, -_stats.MaxSpeed, _stats.MaxSpeed);
        }

        public void Slowdown()
        {
            var acceleration = _stats.BrakingSpeed;
            _speed = Mathf.Clamp(_speed - acceleration, -_stats.MaxSpeed, _stats.MaxSpeed);
        }

        public void Move(float deltaTime)
        {
            var force = _rigidbody.transform.forward * _speed;
            var smoothedForce = force * deltaTime;
            _rigidbody.AddForce(smoothedForce, ForceMode.VelocityChange);
        }

        public void Rotate(float deltaTime, float xDirection)
        {
            var transform = _rigidbody.transform;
            var right = transform.right;
            var direction = right * xDirection;
            var error = Vector3.Dot(direction, right);
            var angle = _rotateRegulator.Calculate(error, deltaTime);
            var torque = new Vector3(0, angle * _stats.TurningSpeed * deltaTime, 0);
            _rigidbody.angularVelocity = torque;
        }
    }
}