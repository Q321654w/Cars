using System.Linq;
using Features.Cars.Engines;
using UnityEngine;

namespace Features.Cars
{
    [CreateAssetMenu(menuName = "CarFactory")]
    public class CarFactory : ScriptableObject
    {
        [SerializeField] private CarConfig[] _configs;
        [SerializeField] private EngineFactory _engineFactory;

        public Car Create(int id)
        {
            var config = _configs.Single(s => s.Id == id);
            
            var instance = Object.Instantiate(config.CarPrefab);
            var rigidbody = instance.GetComponent<Rigidbody>();
            
            var engine = _engineFactory.Create(config.EngineId, rigidbody);
            instance.Initialize(engine);
            
            return instance;
        }
    }
}