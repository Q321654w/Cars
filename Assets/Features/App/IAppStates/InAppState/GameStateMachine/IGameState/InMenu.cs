using DefaultNamespace.Features;

namespace DefaultNamespace
{
    public class InMenu : IGameState
    {
        private readonly IWindow _window;

        public InMenu(IWindow window)
        {
            _window = window;
        }

        public void Enter()
        {
            _window.Show();
        }

        public void Exit()
        {
            _window.Hide();
        }
    }
}