using UnityEngine;

namespace Features
{
    public class CarMarker : MonoBehaviour
    {
        [SerializeField] private int _carId;
        
        public int CarId => _carId;
    }
}