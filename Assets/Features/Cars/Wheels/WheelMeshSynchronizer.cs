using UnityEngine;

namespace DefaultNamespace.Features
{
    public class WheelMeshSynchronizer : MonoBehaviour
    {
        [SerializeField] private WheelCollider _wheelCollider;
        [SerializeField] private Transform _mesh;

        public WheelCollider WheelCollider => _wheelCollider;

        public void LateUpdate()
        {
            WheelCollider.GetWorldPose(out var position, out var rotation);
            _mesh.position = position;
            _mesh.rotation = rotation;
        }
    }
}