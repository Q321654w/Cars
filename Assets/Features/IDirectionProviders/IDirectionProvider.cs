using UnityEngine;

namespace Features.IDirectionProviders
{
    public interface IDirectionProvider
    {
        Vector3 GetDirection();
    }
}