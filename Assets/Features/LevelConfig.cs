using Features.Maps;
using UnityEngine;

namespace Features
{
    [CreateAssetMenu(menuName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private Map _mapPrefab;
        [SerializeField] private int _loops;
        
        public Map MapPrefab => _mapPrefab;
        public int Loops => _loops;
    }
}