using Features.Cars;
using Features.GameUpdate;

namespace Features
{
    public abstract class Driver : IGameUpdate
    {
        protected Car Car;

        public Driver(Car car)
        {
            Car = car;
        }

        public void GameUpdate(float deltaTime)
        {
            var xDirection = GetXDirection();
            Car.Rotate(deltaTime, xDirection);

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