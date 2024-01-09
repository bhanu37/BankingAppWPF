using BankingSystem.Model.Entities;
using BankingSystem.Utilities.Commands;
using BankingSystem.Utilities.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BankingSystem.ViewModel
{
    public class NavigationSideBarVM : ViewModelBase
    {
        public string Name => _loggedAccount.Name;
        public string Email => _loggedAccount.Email;
        public LoggedAccount _loggedAccount;

        public ICommand NavigateToHome { get; set; }
        public ICommand NavigateToProfile { get; set; }
        public ICommand NavigateToTransactions { get; set; }

        public NavigationSideBarVM(LoggedAccount loggedAccount, NavigationStore _navigationStore)
        {
            _loggedAccount = loggedAccount;
            NavigateToHome = new NavigationCommand(_navigationStore, () => new HomeVM());
            NavigateToProfile = new NavigationCommand(_navigationStore, () => new ProfileVM(_loggedAccount, _navigationStore));
            NavigateToTransactions = new NavigationCommand(_navigationStore, () => new TransactionsVM());
        }
    }
}
