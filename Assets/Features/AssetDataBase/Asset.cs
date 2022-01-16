using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Asset")]
    public class Asset : ScriptableObject
    {
        [SerializeField] private Behaviour _prefab;
        [SerializeField] private string _id;

        public Behaviour Prefab => _prefab;
        public string Id => _id;
    }
}