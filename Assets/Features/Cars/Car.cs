using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Features;
using Features.Cars.Engines;
using Features.GameUpdate;
using UnityEngine;

namespace Features.Cars
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshCollider))]
    public class Car : MonoBehaviour, IGameUpdate
    {
        [SerializeField] private WheelMarker[] _wheelMarkers;
        public WheelMarker[] WheelMarkers => _wheelMarkers;

        private Engine _engine;
        private Wheel[] _wheels;

        public Wheel[] RotateWheels => _engine.RotateWheels;

        public void Initialize(Engine engine, IEnumerable<Wheel> wheels)
        {
            _engine = engine;
            _wheels = wheels.ToArray();
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
            
            foreach (var wheel in _wheels)
            {
                wheel.GameUpdate(deltaTime);
            }
        }

        public void Brake()
        {
            _engine.Brake();
        }
    }
}