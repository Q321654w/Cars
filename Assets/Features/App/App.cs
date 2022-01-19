using UnityEngine;

namespace DefaultNamespace
{
    public class App
    {
        private readonly AppInfoContainer _container;
        private ExecuteChain _chain;

        public App()
        {
            _container = new AppInfoContainer();
        }

        public void Start() =>
            _chain = new ExecuteChain()
                .Append(new LoadApp(_container))
                .Append(new InApp(_container))
                .Append(new ExitApp(_container, Quit))
                .Run();
        

        private void Quit() =>
            Application.Quit();
    }
}