using UnityEngine;

namespace Features
{
    public class CarMarker : MonoBehaviour
    {
        public void MoToMe(Transform otherTransform)
        {
            otherTransform.position = transform.position;
            otherTransform.rotation = transform.rotation;
        }
    }
}