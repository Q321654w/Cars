using System.Collections.Generic;
using UnityEngine;

namespace Features.GameUpdate
{
    public class GameUpdates : MonoBehaviour
    {
        private List<IGameUpdate> _updates;
        private bool _isStopped = true;

        private void Awake()
        {
            _updates = new List<IGameUpdate>();
        }

        public void AddToUpdateList(IGameUpdate gameUpdate)
        {
            _updates.Add(gameUpdate);
        }

        private void RemoveFromUpdateList(IGameUpdate gameUpdate)
        {
            var index = _updates.FindIndex(s => s == gameUpdate);
            var lastIndex = _updates.Count - 1;
            _updates[index] = _updates[lastIndex];
            _updates.RemoveAt(lastIndex);
        }

        private void Update()
        {
            if (_isStopped) 
                return;

            for (var i = 0; i < _updates.Count; i++)
            {
                _updates[i].GameUpdate(Time.deltaTime);
            }
        }

        public void StopUpdate()
        {
            _isStopped = true;
        }

        public void ResumeUpdate()
        {
            _isStopped = false;
        }

        public void CleanUp()
        {
            for (int i = _updates.Count - 1; i >= 0 ; i--)
            {
                _updates.RemoveAt(i);
            }
        }
    }
}