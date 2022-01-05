using Features;
using Features.Cars;
using Features.GameUpdate;
using UnityEngine;

namespace DefaultNamespace.Features
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private CarFactory _carFactory;
        [SerializeField] private PlayerDriverFactory _playerFactory;
        [SerializeField] private string _aiIdContext;
        [SerializeField] private float _threshold;
        [SerializeField] private LevelConfig _config;
        [SerializeField] private GameUpdates _updates;

        private void Start()
        {
            var mapBuilder = new MapBuilder();
            var driverFactories = new IDriverFactory[]
            {
                _playerFactory,
                new AiDriverFactory(_aiIdContext, _threshold, mapBuilder),
            };
            var driverFactory = new DriverFactoryFacade(driverFactories);
            var levelLoader = new LevelLoader(mapBuilder, _carFactory, driverFactory);
            var level = levelLoader.Load(_config);
            _updates.AddToUpdateList(level);
            _updates.ResumeUpdate();
        }
    }
}