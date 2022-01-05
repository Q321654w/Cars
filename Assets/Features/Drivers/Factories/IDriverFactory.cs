using Features.Cars;

namespace Features
{
    public interface IDriverFactory
    {
        bool CanCreate(string id);
        Driver Create(string id, Car car);
    }
}