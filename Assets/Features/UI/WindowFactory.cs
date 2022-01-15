using System;
using DefaultNamespace.Features;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    public class WindowFactory
    {
        private readonly AssetDataBase _assetDataBase;

        public WindowFactory(AssetDataBase assetDataBase)
        {
            _assetDataBase = assetDataBase;
        }

        public IWindow CreateWindow(WindowType type)
        {
            switch (type)
            {
                case WindowType.MainMenu:
                    var prefab = _assetDataBase.GetAsset<MainMenuView>(Constants.MASTER_VIEW_ID);
                    var instance = Object.Instantiate(prefab);
                    return instance;
            }

            throw new Exception();
        }
    }
}