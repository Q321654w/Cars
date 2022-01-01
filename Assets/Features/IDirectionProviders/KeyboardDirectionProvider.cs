using UnityEngine;

namespace Features.IDirectionProviders
{
    public class KeyboardDirectionProvider : IDirectionProvider
    {
        public Vector3 GetDirection()
        {
            var horizontalDirection = Input.GetAxisRaw("Horizontal");
            var verticalDirection = Input.GetAxisRaw("Vertical");
            return new Vector3(horizontalDirection, 0, verticalDirection);
        }
    }
}