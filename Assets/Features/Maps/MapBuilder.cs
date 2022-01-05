using System;
using Features.Maps;
using Object = UnityEngine.Object;

namespace Features
{
    public class MapBuilder
    {
        public event Action<Map> Created;
        
        public Map Build(Map prefab)
        {
            var map = Object.Instantiate(prefab);
            Created?.Invoke(map);
            return map;
        }
    }
}