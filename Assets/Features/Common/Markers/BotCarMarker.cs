using UnityEngine;

namespace Features
{
    public class BotCarMarker : Marker
    {
        [SerializeField] private int _carId = 0;

        public int CarId => _carId;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color;
            Gizmos.DrawCube(transform.position, Size);
        }
    }
}