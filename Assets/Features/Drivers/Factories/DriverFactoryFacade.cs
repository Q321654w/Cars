using Features.Cars;

namespace Features
{
    public class DriverFactoryFacade : IDriverFactory
    {
        private IDriverFactory[] _driverFactories;

        public DriverFactoryFacade(IDriverFactory[] driverFactories)
        {
            _driverFactories = driverFactories;
        }

        public bool CanCreate(string id)
        {
            var canCreate = false;
            foreach (var driverFactory in _driverFactories)
            {
                canCreate = canCreate || driverFactory.CanCreate(id);
            }

            return canCreate;
        }

        public Driver Create(string id, Car car)
        {
            foreach (var driverFactory in _driverFactories)
            {
                if (driverFactory.CanCreate(id))
                    return driverFactory.Create(id, car);
            }

            return null;
        }
    }
}