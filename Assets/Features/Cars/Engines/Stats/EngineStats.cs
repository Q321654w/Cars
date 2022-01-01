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
        
        public float AccelerationSpeed => _accelerationSpeed;
        public float BrakingSpeed => _brakingSpeed;
        public float TurningSpeed => _turningSpeed;

        public EngineStats(float accelerationSpeed, float brakingSpeed, float turningSpeed)
        {
            _accelerationSpeed = accelerationSpeed;
            _brakingSpeed = brakingSpeed;
            _turningSpeed = turningSpeed;
        }
    }
}