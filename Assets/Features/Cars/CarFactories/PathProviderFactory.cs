using Features.IDirectionProviders;
using PathCreation;

namespace Features.Cars.CarBuilders
{
    public class PathProviderFactory
    {
        private readonly VertexPath _vertexPath;

        public PathProviderFactory(VertexPath vertexPath)
        {
            _vertexPath = vertexPath;
        }

        public IDirectionProvider Create(string id)
        {
            
            return new PathDirectionProvider(transform, _vertexPath, 1f);
        }
    }
}