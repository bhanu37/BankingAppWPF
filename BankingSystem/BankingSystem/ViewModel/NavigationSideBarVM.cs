using BankingSystem.Model.Entities;
using BankingSystem.Utilities.Commands;
using BankingSystem.Utilities.Services.DialogsService;
using BankingSystem.Utilities.Stores;
using BankingSystem.View.PopupsAndDialogs;
using BankingSystem.ViewModel.PopupsAndDialogsVM;
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
        private IDialogService _dialogService;
        private LoggedAccount _loggedAccount;
        private NavigationStore _navigationStore;

        public string Name => _loggedAccount.Name;
        public string Email => _loggedAccount.Email;

        public ICommand NavigateToHome { get; set; }
        public ICommand NavigateToProfile { get; set; }
        public ICommand NavigateToTransactions { get; set; }
        public ICommand SendMoneyCommand { get; set; }

        public NavigationSideBarVM(LoggedAccount loggedAccount, NavigationStore navigationStore)
        {
            _loggedAccount = loggedAccount;
            _navigationStore = navigationStore;
            _dialogService = new OperationalDialogs();
            NavigateToHome = new NavigationCommand(_navigationStore, () => new HomeVM());
            NavigateToProfile = new NavigationCommand(_navigationStore, () => new ProfileVM(_loggedAccount, _navigationStore));
            NavigateToTransactions = new NavigationCommand(_navigationStore, () => new TransactionsVM(_loggedAccount));
            SendMoneyCommand = new FunctionalCommand(SendMoney);
        }

        private void SendMoney()
        {
            _dialogService.ShowDialog(new SendMoneyDialogView(), new SendMoneyDialogVM(_loggedAccount, _navigationStore));
        }
    }
}
