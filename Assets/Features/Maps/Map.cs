using Features.Cars;
using PathCreation;
using UnityEngine;

namespace Features.Maps
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private BotCarMarker[] _carMarkers;
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private Finish _finish;

        public BotCarMarker[] CarMarkers => _carMarkers;
        public int MaxCarCount => _carMarkers.Length;
        public VertexPath VertexPath => _pathCreator.path;
        public Finish Finish => _finish;
        
        public void PlaceCar(Car car, int index)
        {
            var carTransform = car.transform;

            carTransform.position = _carMarkers[index].transform.position;
            carTransform.rotation = _carMarkers[index].transform.rotation;
        }
    }
}