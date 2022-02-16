using Features.GameUpdate;
using UnityEngine;

namespace DefaultNamespace.Features
{
    public class WheelMeshSynchronizer : IGameUpdate
    {
        private readonly WheelCollider _wheelCollider;
        private readonly Transform _mesh;

        public WheelCollider WheelCollider => _wheelCollider;

        public WheelMeshSynchronizer(WheelCollider wheelCollider, Transform mesh)
        {
            _wheelCollider = wheelCollider;
            _mesh = mesh;
        }

        public void GameUpdate(float deltaTime)
        {
            WheelCollider.GetWorldPose(out var position, out var rotation);
            _mesh.position = position;
            _mesh.rotation = rotation;
        }
    }
}