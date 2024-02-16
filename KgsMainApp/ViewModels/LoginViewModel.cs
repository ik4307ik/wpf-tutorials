using System.Windows.Input;
using KgsMainApp.Commands;
using KgsMainApp.Services;

namespace KgsMainApp.ViewModels
{

    public class LoginViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }

        private INavigationService _homeNavigationService;

        public ICommand LoginCommand { get; }

        public LoginViewModel(INavigationService homeNavigationService)
        {
            _homeNavigationService = homeNavigationService;
            LoginCommand = new CallbackCommand(aaa, bbb);
            //NavigateHomeCommand = new NavigateCommand(homeNavigationService);
        }

        private bool bbb()
        {
            return true;
        }

        private void aaa()
        {
            _homeNavigationService.Navigate();
        }

        public string WelcomeMessage => "Welcome to Login view.";
    }
}
