using System;
using Features;

namespace DefaultNamespace
{
    public class InSelectingLevel : IGameState, ILevelConfigProvider
    {
        public event Action<LevelConfig> ConfigSelected;
        private LevelConfig _levelConfig;

        public void SelectLevel(LevelConfig config)
        {
            _levelConfig = config;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            ConfigSelected?.Invoke(_levelConfig);
        }
    }
}