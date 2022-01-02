using Features.Cars.Engines;
using Features.GameUpdate;
using UnityEngine;

namespace Features.Cars
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Car : MonoBehaviour, IGameUpdate
    {
        private IDirectionProvider _directionProvider;
        private Engine _engine;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize(Engine engine, IDirectionProvider directionProvider)
        {
            _directionProvider = directionProvider;
            _engine = engine;
        }

        public void GameUpdate(float deltaTime)
        {
            var direction = _directionProvider.GetDirection();
            _engine.Move(deltaTime, direction, _rigidbody);
            _engine.Rotate(deltaTime, direction, _rigidbody);
        }
    }
}