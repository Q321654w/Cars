using UnityEngine;

namespace Features
{
    public abstract class Marker : MonoBehaviour
    {
        [SerializeField] protected Color Color;
        [SerializeField] protected Vector3 Size;

        public void MoToMe(Transform otherTransform)
        {
            otherTransform.position = transform.position;
            otherTransform.rotation = transform.rotation;
        }
    }
}