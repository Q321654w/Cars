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

        private readonly Dictionary<Car, Driver> _cars;
        private readonly Dictionary<Car, int> _loops;
        private readonly int _winLoopCount;
        private readonly Queue<Car> _scoreBoard;

        public Level(Map map, int winLoopCount, Dictionary<Car, Driver> drivers)
        {
            _scoreBoard = new Queue<Car>();
            _loops = new Dictionary<Car, int>();
            _map = map;
            _winLoopCount = winLoopCount;

            _cars = drivers;

            foreach (var pair in _cars)
            {
                _loops.Add(pair.Key, 0);
            }

            _map.Finish.Reached += OnFinishReached;
        }

        private void OnFinishReached(Car car)
        {
            _loops[car] += 1;

            if (_loops[car] >= _winLoopCount)
                AddToScoreBoard(car);

            if (_scoreBoard.Count == _cars.Count)
                CompleteLevel();
        }

        private void AddToScoreBoard(Car car)
        {
            _scoreBoard.Enqueue(car);
            _cars.Remove(car);
        }

        private void CompleteLevel()
        {
            _map.Finish.Reached -= OnFinishReached;
            Completed?.Invoke(_scoreBoard);
        }

        public void GameUpdate(float deltaTime)
        {
            foreach (var driverCarPair in _cars)
            {
                var car = driverCarPair.Key;
                var driver = driverCarPair.Value;

                car.GameUpdate(deltaTime);
                driver.GameUpdate(deltaTime);
            }
        }
    }
}