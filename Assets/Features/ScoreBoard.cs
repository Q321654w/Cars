using Features.Cars;

namespace Features
{
    public class ScoreBoard
    {
        private Car[] _cars;
        private int _currentIndex;
        
        public ScoreBoard(int carsCount)
        {
            _cars = new Car[carsCount];
            _currentIndex = 0;
        }

        public void AddCar(Car car)
        {
            _cars[_currentIndex] = car;
            _currentIndex++;
        }
    }
}