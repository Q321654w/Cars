using Features.GameUpdate;
using UnityEngine;

namespace DefaultNamespace.Features
{
    public class Wheel : MonoBehaviour, IGameUpdate
    {
        [SerializeField] private float _maxRotationAngle;
        private WheelMeshSynchronizer _meshSynchronizer;

        public float Angle => _meshSynchronizer.WheelCollider.steerAngle;

        public void Initialize(WheelMeshSynchronizer wheelMeshSynchronizer)
        {
            _meshSynchronizer = wheelMeshSynchronizer;
        }

        public void AddSteerAngle(float angle)
        {
            var steeringAngle = _meshSynchronizer.WheelCollider.steerAngle;
            steeringAngle += angle;
            _meshSynchronizer.WheelCollider.steerAngle = Mathf.Clamp(steeringAngle, -_maxRotationAngle, _maxRotationAngle);
        }

        public void SetTorque(float smoothedForce)
        {
            _meshSynchronizer.WheelCollider.motorTorque = smoothedForce;
        }

        public void SetBrake(float brakeForce)
        {
            _meshSynchronizer.WheelCollider.brakeTorque = brakeForce;
        }

        public void GameUpdate(float deltaTime)
        {
            _meshSynchronizer.GameUpdate(deltaTime);
        }
    }
}