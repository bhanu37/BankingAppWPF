using BankingSystem.Utilities.Stores;
using BankingSystem.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentVM = new LoginVM(navigationStore);

            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
