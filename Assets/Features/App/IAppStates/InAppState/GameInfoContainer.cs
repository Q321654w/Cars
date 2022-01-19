using Features;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInfoContainer
    {
        public Camera Camera { get; set; }

        public Settings Settings { get; set; }

        public LevelConfig[] LevelConfigs { get; set; }

        public float Treshold { get; set; }

        //TODO
    }
}