namespace DefaultNamespace
{
    public class InMenu : IGameState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly MainMenuView _mainMenuView;

        public InMenu(WindowFactory windowFactory, IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
            _mainMenuView = windowFactory.CreateMainMenu();
            _mainMenuView.StartButton.Pressed += OnStartButtonPressed;
        }

        private void OnStartButtonPressed()
        {
            _stateSwitcher.SwitchState<InSelectingLevel>();
            _mainMenuView.Hide();
        }

        public void Enter()
        {
            _mainMenuView.Show();
        }
    }
}