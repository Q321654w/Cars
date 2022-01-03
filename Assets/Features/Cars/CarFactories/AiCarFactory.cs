using System.Linq;
using UnityEngine;

namespace Features.Cars
{
    public class AiCarFactory
    {
        private AiConfig[] _aiCarConfigs;
        
        public Car Create(int id)
        {
            var config = _aiCarConfigs.Single(s => s.Id == id);
            var instance = Object.Instantiate(config.CarPrefab);
            
            return instance;
        }
    }
}