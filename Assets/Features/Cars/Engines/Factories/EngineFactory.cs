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

        public Engine Create(int id, IEnumerable<Wheel> wheels)
        {
            var config = _configs.Single(s => s.Id == id);
            return new Engine(config.Stats, config.PidRegulator, wheels);
        }

        public Engine Create(EngineConfig config, IEnumerable<Wheel> wheels)
        {
            return new Engine(config.Stats, config.PidRegulator, wheels);
        }
    }
}