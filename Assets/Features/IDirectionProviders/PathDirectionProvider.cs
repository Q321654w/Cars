using DefaultNamespace;
using PathCreation;
using UnityEngine;

namespace Features.IDirectionProviders
{
    public class PathDirectionProvider : IDirectionProvider
    {
        private readonly Transform _transform;
        private readonly VertexPath _path;
        private readonly float _threshold;
        private const float Z_DIRECTION = 1F;

        public PathDirectionProvider(Transform transform, VertexPath path, float threshold)
        {
            _transform = transform;
            _path = path;
            _threshold = threshold;
        }

        public Vector3 GetDirection()
        {
            var position = _transform.position;
            var distanceAlongPath = _path.GetClosestDistanceAlongPath(position);
            var point = _path.GetPointAtDistance(distanceAlongPath);
            DebugDrawer.DrawCross(point, 3, Color.red, Time.deltaTime);

            var distance = Vector3.Distance(position, point);
            distanceAlongPath += distance + _threshold;
            point = _path.GetPointAtDistance(distanceAlongPath);

            var pathDirection = (point - position).normalized;
            DebugDrawer.DrawCross(point, 3, Color.yellow, Time.deltaTime);
            var currentDirection = _transform.right;

            var dot = Vector3.Dot(pathDirection, currentDirection);
            dot = dot < 0 ? -1 : 1;
            return new Vector3(dot, 0, Z_DIRECTION);
        }
    }
}