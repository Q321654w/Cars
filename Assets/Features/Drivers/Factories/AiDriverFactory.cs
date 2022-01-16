using DefaultNamespace;
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

        public AiDriverFactory(float threshold, MapBuilder mapBuilder)
        {
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
            return id.Contains(Constants.AI_ID_CONTEXT);
        }

        public Driver Create(string id, Car car)
        {
            return new Ai(car, _vertexPath, _threshold);
        }
    }
}