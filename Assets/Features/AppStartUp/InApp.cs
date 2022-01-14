using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class InApp : IAppState
    {
        public event Action Ended;

        private readonly AppInfoContainer _appInfoContainer;
        private GameStateMachine _gameStateMachine;

        public InApp(AppInfoContainer appInfoContainer)
        {
            _appInfoContainer = appInfoContainer;

            var masterViewPrefab = _appInfoContainer.GameInfoContainer.AssetDataBase.GetAsset<MasterView>(Constants.MASTER_VIEW_ID);

            var inMenu = new InMenu(_appInfoContainer.GameInfoContainer.Settings);
            var loadGame = new LoadGame();
            var inGame = new InGame();
            var pause = new Pause();
            var endGame = new EndGame();

            var states = new Dictionary<IGameState, IEnumerable<Transition>>()
            {
                [inMenu] = new List<Transition>()
                {
                    new Transition(loadGame),
                },
                [loadGame] = new List<Transition>()
                {
                    
                },
            };

            _gameStateMachine = new GameStateMachine(states, inMenu);
        }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}