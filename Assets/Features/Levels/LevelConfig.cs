using Features.Maps;
using UnityEngine;

namespace Features
{
    [CreateAssetMenu(menuName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private string[] _driverIds;
        [SerializeField] private Map _mapPrefab;
        [SerializeField] private int _loops;

        public Map MapPrefab => _mapPrefab;
        public int Loops => _loops;
        public string[] DriverIds => _driverIds;

        public void OnValidate()
        {
            var length = _mapPrefab.BotMarkers.Length;

            if (_driverIds.Length != length)
            {
                var lastIds = _driverIds;
                _driverIds = new string[length];
                for (int i = 0; i < _driverIds.Length; i++)
                {
                    if (i >= lastIds.Length)
                        return;
                    _driverIds[i] = lastIds[i];
                }
            }
        }
    }
}