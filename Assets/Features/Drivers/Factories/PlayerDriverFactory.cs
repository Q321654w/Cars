using Features.Cars;
using UnityEngine;

namespace Features
{
    [CreateAssetMenu(menuName = "PlayerDriverFactory")]
    public class PlayerDriverFactory : ScriptableObject, IDriverFactory
    {
        [SerializeField] private string _idContext;

        public PlayerDriverFactory(string idContext)
        {
            _idContext = idContext;
        }

        public bool CanCreate(string id)
        {
            return id.Contains(_idContext);
        }

        public Driver Create(string id, Car car)
        {
            return new Player(car);
        }
    }
}