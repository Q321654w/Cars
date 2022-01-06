using System;
using UnityEngine;

namespace Features.Cars.Engines.Stats
{
    [Serializable]
    public struct EngineStats
    {
        [SerializeField] private float _accelerationSpeed;
        [SerializeField] private float _brakingSpeed;
        [SerializeField] private float _turningSpeed;
        [SerializeField] private float _maxSpeed;

        public float AccelerationSpeed => _accelerationSpeed;
        public float BrakingSpeed => _brakingSpeed;
        public float TurningSpeed => _turningSpeed;
        public float MaxSpeed => _maxSpeed;

        public EngineStats(float accelerationSpeed, float brakingSpeed, float turningSpeed, float maxSpeed)
        {
            _accelerationSpeed = accelerationSpeed;
            _brakingSpeed = brakingSpeed;
            _turningSpeed = turningSpeed;
            _maxSpeed = maxSpeed;
        }
    }
}