using UnityEngine;

namespace DefaultNamespace.Features
{
    [CreateAssetMenu(menuName = "WheelPrefabPair")]
    public class WheelPrefabPair : ScriptableObject
    {
        [SerializeField] private Wheel _rightWheelPrefab;
        [SerializeField] private Wheel _leftWheelPrefab;

        public Wheel GetPrefab(bool isRightWheel)
        {
            return isRightWheel ? _rightWheelPrefab : _leftWheelPrefab;
        }
    }
}