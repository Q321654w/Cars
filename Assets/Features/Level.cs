using System.Collections.Generic;
using Features.Cars;
using Features.GameUpdate;
using Features.Maps;

namespace Features
{
    public class Level
    {
        private readonly GameUpdates _updates;
        private readonly Map _map;
        private readonly Dictionary<Car, int> _loops;
        private readonly int _winLoopCount;

        private readonly ScoreBoard _scoreBoard;

        public Level(Map map, int winLoopCount, ScoreBoard scoreBoard, GameUpdates updates)
        {
            _loops = new Dictionary<Car, int>();
            _map = map;
            _winLoopCount = winLoopCount;
            _scoreBoard = scoreBoard;
            _updates = updates;
        }
        
        public void Start(IEnumerable<Car> cars)
        {
            _map.Finish.Reached += OnFinishReached;
            
            foreach (var car in cars)
            {
                _loops.Add(car, 0);
                _updates.AddToUpdateList(car);
            }
            
            _map.PlaceCars(cars);
            
            _updates.ResumeUpdate();
        }
        
        private void OnFinishReached(Car car)
        {
            if (_loops[car] >= _winLoopCount)
            {
                _scoreBoard.AddCar(car);
                return;
            }

            _loops[car] += 1;
        }
    }
}