using System;
using Features.GameUpdate;

namespace DefaultNamespace
{
    public interface IGameUpdatesProvider
    {
        event Action<GameUpdates> Instanced;
    }
}