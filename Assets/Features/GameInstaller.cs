using System.Collections.Generic;
using Features.Cars;
using Features.Cars.Engines.Configs;
using Features.GameUpdate;
using UnityEngine;

namespace Features
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private GameUpdates _gameUpdates;
        [SerializeField] private CarConfig[] _carConfigs;
        [SerializeField] private EngineConfig[] _engineConfigs;

        private void Awake()
        {
           
            var levelBuilder = new LevelBuilder(carFactoryBuilder);
            var level = levelBuilder.Build(_levelConfig);
            level.Completed += OnLevelCompleted;
            _gameUpdates.AddToUpdateList(level);
            _gameUpdates.ResumeUpdate();
        }

        private void OnLevelCompleted(Queue<Car> cars)
        {
            Debug.Log("Completed");
        }
    }
}