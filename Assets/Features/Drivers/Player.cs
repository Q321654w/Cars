using DefaultNamespace.Features;
using Features.Cars;
using UnityEngine;

namespace Features
{
    public class Player : Driver
    {
        private readonly Wheel _wheel;
        private const float MAX_ANGLE = 90;
        
        public Player(Car car) : base(car)
        {
            _wheel = Car.RotateWheels[0];
        }

        protected override float GetXDirection()
        {
            var horizontalDirection = Input.GetAxisRaw("Horizontal");
            
            if (horizontalDirection == 0)
            {
                var transform = Car.transform;
                var steerAngleInRadians = _wheel.SteerAngle * Mathf.Deg2Rad;
                var localDirection = new Vector3(Mathf.Sin(steerAngleInRadians), 0, Mathf.Cos(steerAngleInRadians));
                var globalDirection = transform.TransformDirection(localDirection);
                return Vector3.SignedAngle(globalDirection, transform.forward, transform.up);
            }
            
            return horizontalDirection * MAX_ANGLE;
        }

        protected override float GetZDirection()
        {
            return Input.GetAxis("Vertical");
        }
    }
}