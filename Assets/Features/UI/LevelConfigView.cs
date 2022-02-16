using System;
using Features;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelConfigView : MonoBehaviour
    {
        public event Action<int> Selected;
        
        [SerializeField] private CustomButton _button;
        
        private int _id;
        
        public void Initialize(int id)
        {
            _id = id;
            _button.Pressed += OnButtonPressed;
            
            _button.Initialize($"{id}");
        }

        private void OnButtonPressed()
        {
            Selected?.Invoke(_id);
        }
    }
}