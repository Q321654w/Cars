using System;
using Features;

namespace DefaultNamespace
{
    public interface ILevelProvider
    {
        event Action<Level> Loaded;
    }
}