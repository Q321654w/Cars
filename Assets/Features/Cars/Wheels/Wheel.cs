﻿using UnityEngine;

namespace DefaultNamespace.Features
{
    public class Wheel : MonoBehaviour
    {
        [SerializeField] private WheelPosition _position;
        [SerializeField] private WheelMeshSynchronizer _meshSynchronizer;
        [SerializeField] private float _maxRotationAngle;

        public WheelPosition Position => _position;

        public void AddSteerAngle(float angle)
        {
            var steeringAngle = _meshSynchronizer.WheelCollider.steerAngle;
            steeringAngle += angle;
            _meshSynchronizer.WheelCollider.steerAngle = Mathf.Clamp(steeringAngle, -_maxRotationAngle, _maxRotationAngle);
        }

        public void AddTorque(float smoothedForce)
        {
            _meshSynchronizer.WheelCollider.motorTorque = smoothedForce;
        }
    }
}