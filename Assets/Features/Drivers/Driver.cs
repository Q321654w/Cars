using Features.Cars;
using Features.GameUpdate;

namespace Features
{
    public abstract class Driver : IGameUpdate
    {
        protected readonly Car Car;
        public Car ControlledCar => Car;
        
        protected Driver(Car car)
        {
            Car = car;
        }
        
        public void GameUpdate(float deltaTime)
        {
            var xDirection = GetXDirection();
            Car.Rotate(xDirection);

            var yDirection = GetZDirection();

            if (yDirection > 0)
            {
                Car.Accelerate();
                return;
            }

            if (yDirection < 0)
            {
                Car.Slowdown();
            }
        }

        protected abstract float GetXDirection();
        protected abstract float GetZDirection();
    }
}