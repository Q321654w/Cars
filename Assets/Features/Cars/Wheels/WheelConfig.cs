using UnityEngine;

namespace DefaultNamespace.Features
{
    [CreateAssetMenu(menuName = "WheelConfig")]
    public class WheelConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private WheelPrefabPair _pair;
        [SerializeField] private WheelCollider _colliderPrefab;

        public int Id => _id;
        public WheelCollider ColliderPrefab => _colliderPrefab;

        public Wheel GetWheelPrefab(bool isRightWheel)
        {
            return _pair.GetPrefab(isRightWheel);
        }
    }
}