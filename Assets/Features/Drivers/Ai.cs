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
        private readonly Wheel _wheel;

        private const float MAX_DISTANCE = 10F;
        private const float Y_DIRECTION = 1F;

        public Ai(Car car, VertexPath path, float threshold) : base(car)
        {
            _path = path;
            _threshold = threshold;
            _wheel = Car.Wheels.First(s => s.IsRotate);
        }

        protected override float GetXDirection()
        {
            var transform = Car.transform;
            var position = transform.position;

            var pathDirection = CalculatePathDirection(position);

            var globalDirection = CalculateGlobalDirection(transform);

            Debug.DrawRay(transform.position + Vector3.up, globalDirection, Color.black, Time.deltaTime);
            Debug.DrawRay(transform.position + Vector3.up, pathDirection, Color.red, Time.deltaTime);

            var angle = Vector3.SignedAngle(globalDirection, pathDirection, transform.up);
            return angle;
        }

        private Vector3 CalculatePathDirection(Vector3 position)
        {
            var distanceAlongPath = CalculateDistanceAlongPath(position);
            var point = _path.GetPointAtDistance(distanceAlongPath);
            DebugDrawer.DrawCross(point,2,Color.red, Time.deltaTime);
            
            return (point - position).normalized;
        }

        private float CalculateDistanceAlongPath(Vector3 position)
        {
            var distanceAlongPath = _path.GetClosestDistanceAlongPath(position);
            
            var point = _path.GetPointAtDistance(distanceAlongPath);
            DebugDrawer.DrawCross(point,2,Color.yellow, Time.deltaTime);
            
            var distance = Vector3.Distance(position, point);
            var clampedDistance = Mathf.Clamp(distance, 0, MAX_DISTANCE); 
            distanceAlongPath += clampedDistance + _threshold;

            return distanceAlongPath;
        }

        private Vector3 CalculateGlobalDirection(Transform transform)
        {
            var steerAngleInRadians = _wheel.Angle * Mathf.Deg2Rad;
            var localDirection = new Vector3(Mathf.Sin(steerAngleInRadians), 0, Mathf.Cos(steerAngleInRadians));
            
            return transform.TransformDirection(localDirection);
        }

        protected override float GetZDirection()
        {
            return Y_DIRECTION;
        }
    }
}