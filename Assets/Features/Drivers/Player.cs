using System.Linq;
using DefaultNamespace.Features;
using Features.Cars;
using UnityEngine;

namespace Features
{
    public class Player : Driver
    {
        private Wheel _frontRightWheel;
        private const float MAX_ANGLE = 90;
        
        public Player(Car car) : base(car)
        {
            _frontRightWheel = Car.Wheels.Single(s => s.Position == WheelPosition.FrontRight);
        }

        protected override float GetXDirection()
        {
            var horizontalDirection = Input.GetAxis("Horizontal");
            
            if (horizontalDirection == 0)
            {
                var transform = Car.transform;
                var steerAngleInRadians = _frontRightWheel.SteerAngle * Mathf.Deg2Rad;
                var localDirection = new Vector3(Mathf.Sin(steerAngleInRadians), 0, Mathf.Cos(steerAngleInRadians));
                var globalDirection = transform.TransformDirection(localDirection);
                return Vector3.SignedAngle(globalDirection, transform.forward, transform.up);
            }
            
            return horizontalDirection;
        }

        protected override float GetZDirection()
        {
            return Input.GetAxis("Vertical");
        }
    }
}