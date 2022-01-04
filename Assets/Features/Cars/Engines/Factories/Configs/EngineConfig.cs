using Features.Cars.Engines.Stats;
using UnityEngine;

namespace Features.Cars.Engines.Configs
{
    [CreateAssetMenu(fileName = "EngineConfig")]
    public class EngineConfig : ScriptableObject
    {
        [SerializeField] private PIDRegulator _pidRegulator;
        [SerializeField] private EngineStats _stats;
        [SerializeField] private int _id;

        public EngineStats Stats => _stats;
        public int Id => _id;
        public PIDRegulator PidRegulator => _pidRegulator;
    }
}