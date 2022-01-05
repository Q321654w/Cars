using System;
using UnityEngine;

namespace Features
{
    [Serializable]
    public class PIDRegulator
    {
        [SerializeField] private float _kp;
        [SerializeField] private float _ki;
        [SerializeField] private float _kd;

        private float _lastError;
        private float _i;

        public PIDRegulator(float pFactor, float iFactor, float dFactor)
        {
            _kp = pFactor;
            _ki = iFactor;
            _kd = dFactor;
        }

        public float Calculate(float error, float deltaTime)
        {
            var p = error;
            _i += error * deltaTime;
            var d = (error - _lastError) / deltaTime;
            _lastError = error;

            var co = p * _kp + _i * _ki + d * _kd;

            return co;
        }
    }
}