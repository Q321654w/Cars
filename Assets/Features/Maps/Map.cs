using Features.Cars;
using PathCreation;
using UnityEngine;

namespace Features.Maps
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private PlayerCarMarker _playerMarker;
        [SerializeField] private BotCarMarker[] _botMarkers;
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private Finish _finish;

        public BotCarMarker[] BotMarkers => _botMarkers;
        public int MaxCarCount => _botMarkers.Length;
        public VertexPath VertexPath => _pathCreator.path;
        public Finish Finish => _finish;
        public PlayerCarMarker PlayerMarker => _playerMarker;
    }
}