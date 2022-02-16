using System;
using Features.Cars;

namespace Features
{
    public class DriverFactoryFacade
    {
        private readonly IDriverFactory[] _driverFactories;

        public DriverFactoryFacade(IDriverFactory[] driverFactories)
        {
            _driverFactories = driverFactories;
        }

        public Driver Create(string id, Car car)
        {
            foreach (var driverFactory in _driverFactories)
            {
                if (driverFactory.CanCreate(id))
                    return driverFactory.Create(id, car);
            }

            throw new Exception($"Cant Create Driver by {id}");
        }
    }
}