using DefaultNamespace.Features;
using UnityEngine;

namespace DefaultNamespace
{
    public class InGameView : MonoBehaviour, IWindow
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}