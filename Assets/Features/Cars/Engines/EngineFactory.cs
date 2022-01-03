using System.Linq;
using Features.Cars.Engines.Configs;
using UnityEngine;

namespace Features.Cars.Engines
{
    public class EngineFactory 
    {
        private readonly EngineConfig[] _configs;
        
        public EngineFactory(EngineConfig[] configs)
        {
            _configs = configs;
        }
        
        public Engine Create(int id, Rigidbody rigidbody)
        {
            var config = _configs.Single(s => s.Id == id);
            return new Engine(config.Stats, rigidbody);
        }
    }
}