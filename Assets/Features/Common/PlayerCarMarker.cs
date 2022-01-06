using UnityEngine;

namespace Features
{
    public class PlayerCarMarker : CarMarker
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color;
            Gizmos.DrawCube(transform.position, Size);
        }
    }
}