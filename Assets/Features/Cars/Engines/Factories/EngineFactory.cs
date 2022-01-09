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

        public Engine Create(int id, Wheel frontRight, Wheel frontLeft)
        {
            var config = _configs.Single(s => s.Id == id);
            var moveWheels = new Wheel[2] {frontLeft, frontRight};
            var rotateWheels = new Wheel[2] {frontLeft, frontRight};
            return new Engine(config.Stats, config.PidRegulator, moveWheels, rotateWheels);
        }

        public Engine Create(EngineConfig config, Wheel frontRight, Wheel frontLeft)
        {
            var moveWheels = new Wheel[2] {frontLeft, frontRight};
            var rotateWheels = new Wheel[2] {frontLeft, frontRight};
            return new Engine(config.Stats, config.PidRegulator, moveWheels, rotateWheels);
        }
    }
}