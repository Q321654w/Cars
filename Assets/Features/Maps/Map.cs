using System.Collections.Generic;
using Features.Cars;
using PathCreation;
using UnityEngine;

namespace Features.Maps
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private CarPositionMarker[] _startPositions;
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private Finish _finish;

        public int MaxCarCount => _startPositions.Length;
        public VertexPath VertexPath => _pathCreator.path;
        public Finish Finish => _finish;

        public void PlaceCars(IEnumerable<Car> cars)
        {
            var i = 0;
            foreach (var car in cars)
            {
                var carTransform = car.transform;
                
                carTransform.position = _startPositions[i].transform.position;
                carTransform.rotation = _startPositions[i].transform.rotation;

                i++;
            }
        }
    }
}