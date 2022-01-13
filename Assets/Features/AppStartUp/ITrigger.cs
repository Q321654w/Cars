using System;

namespace DefaultNamespace
{
    public interface ITrigger
    {
        event Action Triggered;
    }
}