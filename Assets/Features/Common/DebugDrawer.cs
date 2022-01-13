using UnityEngine;

namespace DefaultNamespace
{
    public class DebugDrawer
    {
        public static void DrawCross(Vector3 point, float size, Color color, float duration)
        {
            Debug.DrawRay(point + size * Vector3.down, Vector3.up * 2 * size, color, duration);
            Debug.DrawRay(point + size * Vector3.back, Vector3.forward * 2 * size, color, duration);
            Debug.DrawRay(point + size * Vector3.right, Vector3.left * 2 * size, color, duration);
        }
    }
}