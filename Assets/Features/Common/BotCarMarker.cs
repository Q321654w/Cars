using UnityEngine;

namespace Features
{
    public class BotCarMarker : CarMarker
    {
        [SerializeField] private int _carId;
        
        public int CarId => _carId;
    }
}