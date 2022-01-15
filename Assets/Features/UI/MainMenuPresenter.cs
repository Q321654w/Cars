namespace DefaultNamespace
{
    public class MainMenuPresenter
    {
        private readonly MainMenuView _menuView;
        private readonly Transition _loadGameTransition;

        public MainMenuPresenter(MainMenuView menuView, Transition loadGameTransition)
        {
            _menuView = menuView;
            _loadGameTransition = loadGameTransition;
            _menuView.StartButton.Pressed += OnStartButtonPressed;
        }
        
        private void OnStartButtonPressed()
        {
            _loadGameTransition.GoToNextState();
        }
    }
}