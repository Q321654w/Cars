using Features;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "AllConfigs")]
    public class LevelConfigs : ScriptableObject
    {
        [SerializeField] private LevelConfig[] _allConfigs;

        public LevelConfig[] AllConfigs => _allConfigs;
    }
}