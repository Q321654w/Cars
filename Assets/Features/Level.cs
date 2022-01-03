using System;
using System.Collections.Generic;
using System.Linq;
using Features.Cars;
using Features.GameUpdate;
using Features.Maps;

namespace Features
{
    public class Level : IGameUpdate
    {
        public event Action<Queue<Car>> Completed;
        
        private readonly Map _map;

        private readonly Dictionary<Car, int> _loops;
        private readonly int _winLoopCount;

        private readonly Car[] _cars;

        private readonly Queue<Car> _scoreBoard;

        public Level(Map map, int winLoopCount, IEnumerable<Car> cars)
        {
            _scoreBoard = new Queue<Car>();
            _loops = new Dictionary<Car, int>();
            _map = map;
            _winLoopCount = winLoopCount;
            _cars = cars.ToArray();
            
            _map.Finish.Reached += OnFinishReached;
            
            foreach (var car in _cars)
            {
                _loops.Add(car, 0);
            }
        }
        
        private void OnFinishReached(Car car)
        {
            _loops[car] += 1;
            
            if (_loops[car] >= _winLoopCount)
                _scoreBoard.Enqueue(car);

            if (_scoreBoard.Count == _cars.Length)
                Completed?.Invoke(_scoreBoard);
        }

        public void GameUpdate(float deltaTime)
        {
            foreach (var car in _cars)
            {
                car.GameUpdate(deltaTime);
            }
        }
    }
}