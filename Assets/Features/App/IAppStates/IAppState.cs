using System;

namespace DefaultNamespace
{
    public interface IAppState
    {
        event Action Ended;
        
        void Enter();
    }
}