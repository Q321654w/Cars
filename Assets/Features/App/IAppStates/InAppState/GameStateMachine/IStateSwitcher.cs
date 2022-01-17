namespace DefaultNamespace
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IGameState;
    }
}