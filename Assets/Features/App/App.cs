using System.Collections.Generic;
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

        public void Start()
        {
            var queue = new Queue<IAppState>();
            queue.Enqueue(new LoadApp(_container));
            queue.Enqueue(new InApp(_container));
            queue.Enqueue(new ExitApp(_container, Quit));

            _chain = new ExecuteChain(queue);

            _chain.Run();
        }


        private void Quit()
        {
            Application.Quit();
        }
    }
}