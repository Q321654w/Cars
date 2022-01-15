using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class AssetDataBase
    {
        private readonly Asset[] _assets;

        public AssetDataBase()
        {
            _assets = Resources.LoadAll<Asset>("");
        }

        public T GetAsset<T>(string id) where T : MonoBehaviour
        {
            var asset = _assets.Single(s => s.Id == id);

            if (asset.Prefab is T prefab)
                return prefab;

            throw new Exception("Can't find asset with id: " + id);
        }
    }
}