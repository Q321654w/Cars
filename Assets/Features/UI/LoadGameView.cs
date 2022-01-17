using DefaultNamespace.Features;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LoadGameView : MonoBehaviour, IWindow
    {
        [SerializeField] private Slider _progressBar;

        public void SetProgress(float value)
        {
            _progressBar.value = value;
        }

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