using DefaultNamespace;
using PathCreation;
using UnityEngine;

namespace Features.IDirectionProviders
{
    public class PathDirectionProvider
    {
        private readonly VertexPath _path;
        private readonly float _threshold;
        private const float Z_DIRECTION = 1F;

        public PathDirectionProvider(VertexPath path, float threshold)
        {
            _path = path;
            _threshold = threshold;
        }

        public Vector3 GetDirection(Transform transform)
        {
            var position = transform.position;
            var distanceAlongPath = _path.GetClosestDistanceAlongPath(position);
            var point = _path.GetPointAtDistance(distanceAlongPath);
            DebugDrawer.DrawCross(point, 3, Color.red, Time.deltaTime);

            var distance = Vector3.Distance(position, point);
            distanceAlongPath += distance + _threshold;
            point = _path.GetPointAtDistance(distanceAlongPath);

            var pathDirection = (point - position).normalized;
            DebugDrawer.DrawCross(point, 3, Color.yellow, Time.deltaTime);
            var currentDirection = transform.right;

            var dot = Vector3.Dot(pathDirection, currentDirection);
            var sign = Mathf.Sign(dot);
            return new Vector3(dot, 0, Z_DIRECTION);
        }
    }
}