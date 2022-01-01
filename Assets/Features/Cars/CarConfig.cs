using UnityEngine;

namespace Features.Cars
{
    [CreateAssetMenu(fileName = "CarConfig")]
    public class CarConfig : ScriptableObject
    {
        [SerializeField] private Car _carPrefab;
        [SerializeField] private string _id;
        [SerializeField] private string _engineId;
        [SerializeField] private string _directionProviderId;

        public Car CarPrefab => _carPrefab;
        public string Id => _id;
        public string EngineId => _engineId;
        public string DirectionProviderId => _directionProviderId;
    }
}