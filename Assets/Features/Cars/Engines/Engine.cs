using Features.Cars.Engines.Stats;
using UnityEngine;

namespace Features.Cars.Engines
{
    public class Engine
    {
        private readonly IDirectionProvider _directionProvider;
        private readonly Rigidbody _rigidbody;
        private readonly EngineStats _stats;

        public Engine(EngineStats stats, Rigidbody rigidbody, IDirectionProvider directionProvider)
        {
            _stats = stats;
            _rigidbody = rigidbody;
            _directionProvider = directionProvider;
        }

        public void Move(float deltaTime)
        {
            var direction = _directionProvider.GetDirection();
            var acceleration = direction.z < 0 ? _stats.BrakingSpeed : _stats.AccelerationSpeed;
            var force = new Vector3(direction.x * acceleration, 0, direction.z * acceleration);
            var smoothedForce = force * deltaTime;
            _rigidbody.AddRelativeForce(smoothedForce, ForceMode.Acceleration);
        }

        public void Rotate(float deltaTime)
        {
            var direction = _directionProvider.GetDirection();
            var torque = new Vector3(0, direction.x * _stats.TurningSpeed * deltaTime, 0);
            _rigidbody.angularVelocity = torque;
        }
    }
}