using Features.Cars.Engines;
using Features.GameUpdate;
using UnityEngine;

namespace Features.Cars
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Car : MonoBehaviour, IGameUpdate
    {
        private Engine _engine;

        public void Initialize(Engine engine)
        {
            _engine = engine;
        }

        public void Accelerate()
        {
            _engine.Accelerate();
        }

        public void Slowdown()
        {
            _engine.Slowdown();
        }

        public void Rotate(float deltaTime, float direction)
        {
            _engine.Rotate(deltaTime, direction);
        }

        public void GameUpdate(float deltaTime)
        {
            _engine.Move(deltaTime);
        }
    }
}