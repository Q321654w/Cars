using Features.Cars.Engines.Stats;
using UnityEngine;

namespace Features.Cars.Engines
{
    public class Engine
    {
        private readonly EngineStats _stats;

        public Engine(EngineStats stats)
        {
            _stats = stats;
        }

        public void Move(float deltaTime, Vector3 direction, Rigidbody rigidbody)
        {
            var acceleration = direction.z < 0 ? _stats.BrakingSpeed : _stats.AccelerationSpeed;
            var force = new Vector3(direction.x * acceleration, 0, direction.z * acceleration);
            var smoothedForce = force * deltaTime;
            rigidbody.AddRelativeForce(smoothedForce, ForceMode.Acceleration);
        }

        public void Rotate(float deltaTime, Vector3 direction, Rigidbody rigidbody)
        {
            var torque = new Vector3(0, direction.x * _stats.TurningSpeed * deltaTime, 0);
            rigidbody.angularVelocity = torque;
        }
    }
}