using System.Collections.Generic;
using Features.Cars;
using Features.GameUpdate;
using UnityEngine;

namespace Features
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private GameUpdates _gameUpdates;
        [SerializeField] private CarFactory _carFactory;

        private void Awake()
        {
            var map = Instantiate(_levelConfig.MapPrefab);
            var cars = new List<Car>();

            for (var index = 0; index < map.CarMarkers.Length; index++)
            {
                var carMarker = map.CarMarkers[index];
                var car = _carFactory.Create(carMarker.CarId);
                carMarker.MoToMe(car.transform);
                cars.Add(car);
                _gameUpdates.AddToUpdateList(car);
            }

            var level = new Level(map, _levelConfig.Loops, cars);
            level.Completed += OnLevelCompleted;
            var driver = new Player(cars[0]);
            var secondDriver = new Ai(cars[1], map.VertexPath, 5);
            _gameUpdates.AddToUpdateList(driver);
            _gameUpdates.AddToUpdateList(secondDriver);
            _gameUpdates.AddToUpdateList(level);
            _gameUpdates.ResumeUpdate();
        }

        private void OnLevelCompleted(Queue<Car> cars)
        {
            Debug.Log("Completed");
        }
    }
}