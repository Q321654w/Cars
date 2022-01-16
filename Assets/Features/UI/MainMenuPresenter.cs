namespace DefaultNamespace
{
    public class MainMenuPresenter
    {
        private readonly MainMenuView _menuView;
        private readonly Transition _loadGameTransition;

        public MainMenuPresenter(WindowFactory windowFactory, InMenu inMenu, Transition transition)
        {
            inMenu.Entered += OnEntered;
            inMenu.Ended += OnEnded;
            
            _menuView = windowFactory.CreateMainMenu();
            _menuView.StartButton.Pressed += OnStartButtonPressed;
            
            _loadGameTransition = transition;
        }

        private void OnEnded()
        {
            _menuView.Hide();
        }

        private void OnEntered()
        {
            _menuView.Show();
        }

        private void OnStartButtonPressed()
        {
            _loadGameTransition.GoToNextState();
        }
    }
}