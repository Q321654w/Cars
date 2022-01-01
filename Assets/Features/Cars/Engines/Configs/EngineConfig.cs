using Features.Cars.Engines.Stats;
using UnityEngine;

namespace Features.Cars.Engines.Configs
{
    [CreateAssetMenu(fileName = "EngineConfig")]
    public class EngineConfig : ScriptableObject
    {
        [SerializeField] private EngineStats _stats;
        [SerializeField] private string _id;

        public EngineStats Stats => _stats;
        public string Id => _id;
    }
}