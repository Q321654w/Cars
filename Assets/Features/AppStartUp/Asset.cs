using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Asset")]
    public class Asset : ScriptableObject
    {
        [SerializeField] private Object _prefab;
        [SerializeField] private string _id;

        public Object Prefab => _prefab;
        public string Id => _id;
    }
}