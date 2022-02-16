using System;
using System.Collections.Generic;
using Features.Cars;
using Features.GameUpdate;
using Features.Maps;

namespace Features
{
    public class Level : IGameUpdate
    {
        public event Action<Queue<Car>> Completed;

        private readonly Map _map;

        private readonly List<Driver> _drivers;
        private readonly Dictionary<Car, int> _loops;
        private readonly int _winLoopCount;
        private readonly Queue<Car> _scoreBoard;

        public Level(Map map, int winLoopCount, List<Driver> drivers)
        {
            _scoreBoard = new Queue<Car>();
            _loops = new Dictionary<Car, int>();
            _map = map;
            _winLoopCount = winLoopCount;

            _drivers = drivers;

            foreach (var driver in _drivers)
            {
                _loops.Add(driver.ControlledCar, 0);
            }

            _map.Finish.Reached += OnFinishReached;
        }

        private void OnFinishReached(Car car)
        {
            _loops[car] += 1;

            if (_loops[car] >= _winLoopCount)
                AddToScoreBoard(car);

            if (_drivers.Count == 0)
                CompleteLevel();
        }

        private void AddToScoreBoard(Car car)
        {
            _scoreBoard.Enqueue(car);
            
            car.Brake();
            var driver = _drivers.Find(s => s.ControlledCar == car);
            
            _drivers.Remove(driver);
        }

        private void CompleteLevel()
        {
            _map.Finish.Reached -= OnFinishReached;
            Completed?.Invoke(_scoreBoard);
        }

        public void GameUpdate(float deltaTime)
        {
            foreach (var driver in _drivers)
            {
                var car = driver.ControlledCar;
                
                driver.GameUpdate(deltaTime);
                car.GameUpdate(deltaTime);
            }
        }

        public void CleanUp()
        {
            _map.Finish.Reached -= OnFinishReached;
        }
    }
}