using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    public class AssetDataBase
    {
        private readonly Asset[] _assets;

        public AssetDataBase()
        {
            _assets = Resources.LoadAll<Asset>("");
        }

        public T GetAsset<T>(string id) where T : Object
        {
            var asset = _assets.Single(s => s.Id == id);

            switch (asset.Prefab)
            {
                case T prefab:
                    return prefab;
                
                case Behaviour behaviour:
                    behaviour.gameObject.TryGetComponent<T>(out var behaviourPrefab);
                    return behaviourPrefab;

                case GameObject gameObject:
                    gameObject.gameObject.TryGetComponent<T>(out var gameObjectPrefab);
                    return gameObjectPrefab;
                
                default:
                    throw new Exception("Can't find asset with id: " + id);
            }
        }
    }
}