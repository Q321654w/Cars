using DefaultNamespace;
using Features.Cars;
using PathCreation;
using UnityEngine;

namespace Features
{
    public class Ai : Driver
    {
        private readonly VertexPath _path;
        private readonly float _threshold;
        private const float DIRECTION_TOLERANCE = 0.25F;
        private const float Y_DIRECTION = 1F;
        private const float TOLERANCE = 5F;

        public Ai(Car car, VertexPath path, float threshold) : base(car)
        {
            _path = path;
            _threshold = threshold;
        }

        protected override float GetXDirection()
        {
            var transform = Car.transform;
            var position = transform.position;
            var distanceAlongPath = _path.GetClosestDistanceAlongPath(position);
            var point = _path.GetPointAtDistance(distanceAlongPath);
            DebugDrawer.DrawCross(point, 3, Color.red, Time.deltaTime);

            float sign = 0;
            var distance = Vector3.Distance(position, point);
            distanceAlongPath += distance + _threshold;
            point = _path.GetPointAtDistance(distanceAlongPath);

            var pathDirection = (point - position).normalized;
            DebugDrawer.DrawCross(point, 3, Color.yellow, Time.deltaTime);
            var currentDirection = transform.right;
            var dot = Vector3.Dot(pathDirection, currentDirection);

            if (Mathf.Abs(distance) > TOLERANCE || Mathf.Abs(dot) > DIRECTION_TOLERANCE)
            {
                sign = Mathf.Sign(dot);
            }

            return sign;
        }

        protected override float GetZDirection()
        {
            return Y_DIRECTION;
        }
    }
}