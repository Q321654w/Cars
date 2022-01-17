using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    public class AssetDataBase
    {
        private readonly AssetMapper _assetMapper;
        
        private const string PATH = "AssetMapper";

        public AssetDataBase()
        {
            _assetMapper = Resources.Load<AssetMapper>(PATH);
        }

        public T GetAsset<T>(string id) where T : Object
        {
            var asset = _assetMapper.GetAsset(id);

            switch (asset)
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