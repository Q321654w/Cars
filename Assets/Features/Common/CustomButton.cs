using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Features
{
    public class CustomButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Text _text;

        public event Action Pressed;

        public void Initialize(string text)
        {
            _text.text = text;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed?.Invoke();
        }
    }
}