using UnityEngine;

namespace DefaultNamespace
{
    public class AppStartUp : MonoBehaviour
    {
        private void Start()
        {
            var app = new App();
            app.Start();
            Destroy(gameObject);
        }
    }
}