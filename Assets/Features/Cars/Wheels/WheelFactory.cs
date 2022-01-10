using System.Linq;
using UnityEngine;

namespace DefaultNamespace.Features
{
    [CreateAssetMenu(menuName = "WheelFactory")]
    public class WheelFactory : ScriptableObject
    {
        [SerializeField] private WheelConfig[] _configs;

        public Wheel Create(int id, Transform parent, bool isRight)
        {
            var config = _configs.Single(s => s.Id == id);
            
            var colliderInstance = Instantiate(config.ColliderPrefab, parent);
            
            var wheelPrefab = config.GetWheelPrefab(isRight);
            var instance = Instantiate(wheelPrefab, parent);
            
            var wheelMeshSynchronizer = new WheelMeshSynchronizer(colliderInstance, instance.transform);
            instance.Initialize(wheelMeshSynchronizer);
            
            return instance;
        }
    }
}