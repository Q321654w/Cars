using Features.Maps;
using UnityEngine;

namespace Features
{
    [CreateAssetMenu(menuName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private string[] _enemyCarIdes;
        [SerializeField] private Map _mapPrefab;
        [SerializeField] private int _loops;

        public string[] EnemyCarIdes => _enemyCarIdes;
        public Map MapPrefab => _mapPrefab;
        public int Loops => _loops;
    }
}