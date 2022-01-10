using UnityEngine;

namespace Features
{
    public class PlayerCarMarker : Marker
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color;
            Gizmos.DrawCube(transform.position, Size);
        }
    }
}