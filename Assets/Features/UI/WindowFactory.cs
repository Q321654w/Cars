using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    public class WindowFactory
    {
        private readonly Canvas _canvas;
        private readonly AssetDataBase _assetDataBase;

        public WindowFactory(AssetDataBase assetDataBase)
        {
            _assetDataBase = assetDataBase;
            var canvasPrefab = _assetDataBase.GetAsset<Canvas>(Constants.CANVAS_ID);
            _canvas = Object.Instantiate(canvasPrefab);
        }

        public MainMenuView CreateMainMenu()
        {
            var prefab = _assetDataBase.GetAsset<MainMenuView>(Constants.MASTER_VIEW_ID);
            var instance = Object.Instantiate(prefab, _canvas.transform);
            instance.gameObject.SetActive(false);
            return instance;
        }

        public InSelectingLevelView CreateSelectingView()
        {
            var prefab = _assetDataBase.GetAsset<InSelectingLevelView>(Constants.IN_SELECTING_VIEW_ID);
            var instance = Object.Instantiate(prefab, _canvas.transform);
            instance.gameObject.SetActive(false);
            return instance;
        }

        public InGameView CreateInGameView()
        {
            var prefab = _assetDataBase.GetAsset<InGameView>(Constants.IN_GAME_VIEW_ID);
            var instance = Object.Instantiate(prefab, _canvas.transform);
            instance.gameObject.SetActive(false);
            return instance;
        }

        public LoadGameView CreateLoadGameView()
        {
            var prefab = _assetDataBase.GetAsset<LoadGameView>(Constants.LOAD_GAME_VIEW_ID);
            var instance = Object.Instantiate(prefab, _canvas.transform);
            instance.gameObject.SetActive(false);
            return instance;
        }
    }
}