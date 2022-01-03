using System;
using Features.Cars;
using UnityEngine;

namespace Features.Maps
{
    [RequireComponent(typeof(BoxCollider))]
    public class Finish : MonoBehaviour
    {
        public event Action<Car> Reached;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Car>(out var car))
            {
                Reached?.Invoke(car);
            }
        }
    }
}