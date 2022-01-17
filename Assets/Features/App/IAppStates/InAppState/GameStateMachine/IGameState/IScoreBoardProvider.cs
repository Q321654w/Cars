using System;
using System.Collections.Generic;
using Features.Cars;

namespace DefaultNamespace
{
    public interface IScoreBoardProvider
    {
        public event Action<Queue<Car>> Created;
    }
}