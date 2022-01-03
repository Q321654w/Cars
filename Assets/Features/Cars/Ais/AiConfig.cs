using UnityEngine;

namespace Features.Cars
{
    [CreateAssetMenu(fileName = "AiConfig")]
    public class AiConfig : ScriptableObject
    {
        [SerializeField] private Ai _carPrefab;
        [SerializeField] private int _id;
        [SerializeField] private int _engineId;

        public Ai CarPrefab => _carPrefab;
        public int Id => _id;
        public int EngineId => _engineId;
    }
}