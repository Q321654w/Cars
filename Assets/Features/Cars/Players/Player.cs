using Features.Cars.Engines;
using Features.IDirectionProviders;
using UnityEngine;

namespace Features.Cars
{
    public class Player : Car
    {
        private KeyboardDirectionProvider _keyboardDirectionProvider;

        public void Initialize(Engine engine,KeyboardDirectionProvider keyboardDirectionProvider)
        {
            base.Initialize(engine);
            _keyboardDirectionProvider = keyboardDirectionProvider;
        }

        protected override Vector3 GetDirection()
        {
            return _keyboardDirectionProvider.GetDirection();
        }
    }
}