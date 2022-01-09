using System.Linq;
using DefaultNamespace;
using DefaultNamespace.Features;
using Features.Cars;
using PathCreation;
using UnityEngine;

namespace Features
{
    public class Ai : Driver
    {
        private readonly VertexPath _path;
        private readonly float _threshold;
        private readonly Wheel _frontRightWheel;

        private const float Y_DIRECTION = 1F;
        
        public Ai(Car car, VertexPath path, float threshold) : base(car)
        {
            _path = path;
            _threshold = threshold;
            _frontRightWheel = Car.Wheels.Single(s => s.Position == WheelPosition.FrontRight);
        }

        protected override float GetXDirection()
        {
            var transform = Car.transform;
            var position = transform.position;
            var distanceAlongPath = _path.GetClosestDistanceAlongPath(position);
            var point = _path.GetPointAtDistance(distanceAlongPath);
            DebugDrawer.DrawCross(point, 3, Color.red, Time.deltaTime);

            var distance = Vector3.Distance(position, point);
            distanceAlongPath += distance + _threshold;
            point = _path.GetPointAtDistance(distanceAlongPath);

            var pathDirection = (point - position).normalized;
            DebugDrawer.DrawCross(point, 3, Color.yellow, Time.deltaTime);

            var steerAngleInRadians = _frontRightWheel.SteerAngle * Mathf.Deg2Rad;
            var localDirection = new Vector3(Mathf.Sin(steerAngleInRadians), 0, Mathf.Cos(steerAngleInRadians));
            var globalDirection = transform.TransformDirection(localDirection);
            Debug.DrawRay(transform.position + Vector3.up, globalDirection, Color.black, Time.deltaTime);
            Debug.DrawRay(transform.position + Vector3.up, pathDirection, Color.red, Time.deltaTime);
            var angle = Vector3.SignedAngle(globalDirection, pathDirection, transform.up);
            return angle;
        }

        protected override float GetZDirection()
        {
            return Y_DIRECTION;
        }
    }
}