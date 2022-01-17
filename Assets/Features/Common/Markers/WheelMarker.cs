using UnityEngine;

namespace Features
{
    public class WheelMarker : Marker
    {
        [SerializeField] private bool _isRotate;
        [SerializeField] private bool _doesTractionWork;
        [SerializeField] private int _id;
        [SerializeField] private bool _isRightWheel;

        public bool IsRotate => _isRotate;
        public bool DoesTractionWork => _doesTractionWork;
        public int Id => _id;
        public bool IsRightWheel => _isRightWheel;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color;
            Gizmos.DrawCube(transform.position, Size);
        }
    }
}