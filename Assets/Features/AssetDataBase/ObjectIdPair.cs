using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    [Serializable]
    public struct ObjectIdPair
    {
        [SerializeField] private string _key;
        [SerializeField] private Object _value;

        public string Key => _key;
        public Object Value => _value;
    }
}