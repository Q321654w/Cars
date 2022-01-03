using Features.Cars.Engines;
using Features.IDirectionProviders;
using UnityEngine;

namespace Features.Cars
{
    public class Ai : Car
    {
        private PathDirectionProvider _pathDirectionProvider;

        public void Initilalize(Engine engine, PathDirectionProvider pathDirectionProvider)
        {
            base.Initialize(engine);
            _pathDirectionProvider = pathDirectionProvider;
        }

        protected override Vector3 GetDirection()
        {
            return _pathDirectionProvider.GetDirection(transform);
        }
    }
}