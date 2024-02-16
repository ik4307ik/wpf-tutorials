using System.Windows.Input;
using KgsMainApp.Commands;
using KgsMainApp.Services;


namespace KgsMainApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateAccountCommand { get; }

        public HomeViewModel(INavigationService accountNavigationService)
        {
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
        }
    }
}
