using DefaultNamespace.Features;
using Features;
using UnityEngine;

namespace DefaultNamespace
{
    public class MainMenuView : MonoBehaviour, IWindow
    {
        [SerializeField] private CustomButton _startButton;

        public CustomButton StartButton => _startButton;
        
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