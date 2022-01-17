using System.Linq;
using Features;
using UnityEngine;

namespace DefaultNamespace.Features
{
    [CreateAssetMenu(menuName = "WheelFactory")]
    public class WheelFactory : ScriptableObject
    {
        [SerializeField] private WheelConfig[] _configs;

        public Wheel Create(WheelMarker marker)
        {
            var config = _configs.Single(s => s.Id == marker.Id);

            var colliderInstance = Instantiate(config.ColliderPrefab, marker.transform);

            var wheelPrefab = config.GetWheelPrefab(marker.IsRightWheel);
            var instance = Instantiate(wheelPrefab, marker.transform);

            var wheelMeshSynchronizer = new WheelMeshSynchronizer(colliderInstance, instance.transform);
            instance.Initialize(wheelMeshSynchronizer, marker.IsRotate, marker.DoesTractionWork);

            return instance;
        }
    }
}