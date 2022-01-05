using Features.Cars;
using Features.Maps;
using PathCreation;

namespace Features
{
    public class AiDriverFactory : IDriverFactory
    {
        private readonly float _threshold;
        private readonly MapBuilder _mapBuilder;
        private VertexPath _vertexPath;
        private readonly string _idContext;

        public AiDriverFactory(string idContext , float threshold, MapBuilder mapBuilder)
        {
            _idContext = idContext;
            _threshold = threshold;
            _mapBuilder = mapBuilder;
            _mapBuilder.Created += OnCreated;
        }

        private void OnCreated(Map map)
        {
            _mapBuilder.Created -= OnCreated;
            _vertexPath = map.VertexPath;
        }

        public bool CanCreate(string id)
        {
            return id.Contains(_idContext);
        }

        public Driver Create(string id, Car car)
        {
            return new Ai(car, _vertexPath, _threshold);
        }
    }
}