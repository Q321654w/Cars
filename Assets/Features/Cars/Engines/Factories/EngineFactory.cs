using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Features;
using Features.Cars.Engines.Configs;
using UnityEngine;

namespace Features.Cars.Engines
{
    [CreateAssetMenu(menuName = "EngineFactory")]
    public class EngineFactory : ScriptableObject
    {
        [SerializeField] private EngineConfig[] _configs;

        public Engine Create(int id, IEnumerable<Wheel> rotateWheels, IEnumerable<Wheel> moveWheels)
        {
            var config = _configs.Single(s => s.Id == id);
            return new Engine(config.Stats, config.PidRegulator, moveWheels, rotateWheels);
        }

        public Engine Create(EngineConfig config, IEnumerable<Wheel> rotateWheels, IEnumerable<Wheel> moveWheels)
        {
            return new Engine(config.Stats, config.PidRegulator, moveWheels, rotateWheels);
        }
    }
}