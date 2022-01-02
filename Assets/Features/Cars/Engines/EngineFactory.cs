using System.Linq;
using Features.Cars.Engines.Configs;
using UnityEngine;

namespace Features.Cars.Engines
{
    [CreateAssetMenu(menuName = "EngineFactory")]
    public class EngineFactory : ScriptableObject
    {
        [SerializeField] private EngineConfig[] _configs;

        public Engine Create(string id)
        {
            var config = _configs.Single(s => s.Id == id);
            return new Engine(config.Stats);
        }
    }
}