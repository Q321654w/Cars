using Features.Cars.Engines;
using Features.GameUpdate;
using UnityEngine;

namespace Features.Cars
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Car : MonoBehaviour, IGameUpdate
    {
        private Engine _engine;
        protected Rigidbody Rigidbody;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize(Engine engine)
        {
            _engine = engine;
        }

        public void GameUpdate(float deltaTime)
        {
            var direction = GetDirection();
            _engine.Move(deltaTime, direction, Rigidbody);
            _engine.Rotate(deltaTime, direction, Rigidbody);
        }

        protected abstract Vector3 GetDirection();
    }
}