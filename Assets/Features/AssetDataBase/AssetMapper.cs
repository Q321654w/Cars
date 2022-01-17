using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "AssetMapper")]
    public class AssetMapper : ScriptableObject
    {
        [SerializeField] private ObjectIdPair[] _pairs;

        public Object GetAsset(string id)
        {
            return _pairs.Single(s => s.Key == id).Value;
        }
    }
}