using Features.Cars.Engines;
using Features.GameUpdate;
using Features.IDirectionProviders;
using UnityEngine;

namespace Features.Cars
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Car : MonoBehaviour, IGameUpdate
    {
        private Engine _engine;
        protected Rigidbody Rigidbody;
        private IDirectionProvider _directionProvider;

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
            var direction = _directionProvider.GetDirection();
            _engine.Move(deltaTime, direction);
            _engine.Rotate(deltaTime, direction);
        }
    }
}