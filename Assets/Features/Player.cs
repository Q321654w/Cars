using Features.Cars;
using UnityEngine;

namespace Features
{
    public class Player : Driver
    {
        public Player(Car car) : base(car)
        {
        }

        protected override float GetXDirection()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        protected override float GetZDirection()
        {
            return Input.GetAxisRaw("Vertical");
        }
    }
}