using System;
using Features;

namespace DefaultNamespace
{
    public interface ILevelConfigProvider
    {
        event Action<LevelConfig> ConfigSelected;
    }
}