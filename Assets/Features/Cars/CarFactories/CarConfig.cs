using UnityEngine;

namespace Features.Cars
{
    [CreateAssetMenu(fileName = "CarConfig")]
    public class CarConfig : ScriptableObject
    {
        [SerializeField] private Car _carPrefab;
        [SerializeField] private int _id;
        [SerializeField] private int _engineId;

        public Car CarPrefab => _carPrefab;
        public int Id => _id;
        public int EngineId => _engineId;
    }
}