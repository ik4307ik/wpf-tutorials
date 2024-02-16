using System.Windows;
using KgsMainApp.Services;
using KgsMainApp.Stores;
using KgsMainApp.ViewModels;

namespace KgsMainApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _modalNavigationStore = new ModalNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService navigationService = CreateLoginNavigationService();
            navigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }


        private INavigationService CreateHomeNavigationService()
        {
            return new NavigationService<HomeViewModel>(_navigationStore, CreateHomeViewModel);
        }

        private HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel(CreateLoginNavigationService());
        }

        private INavigationService CreateLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(_navigationStore, CreateLoginViewModel);
        }

        private LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(CreateHomeNavigationService());
        }
    }

}
