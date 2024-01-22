using BankingSystem.Model.Entities;
using BankingSystem.Utilities.BusinessLogic;
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

namespace BankingSystem.ViewModel
{
    public class TopBarVM : ViewModelBase
    {
        private readonly LoggedAccount _loggedAccount;
        private readonly NavigationStore _navigationStore;
        private readonly IDialogService _dialogService;
        private double _aCBalance;

        public string PageTitle => _navigationStore.CurrVMTitle;

        public ICommand SendMoneyCommand { get; set; }
        public double AcBalance
        {
            get { return _aCBalance; }
            set 
            { 
                _aCBalance = value; 
                OnPropertyChanged(nameof(AcBalance));
            }
        }


        public TopBarVM(LoggedAccount loggedAccount, NavigationStore navigationStore)
        {
            _loggedAccount = loggedAccount;
            _navigationStore = navigationStore;
            _dialogService = new OperationalDialogs();
            SendMoneyCommand = new FunctionalCommand(SendMoney);
            GetCurrentBankAccountBalance();

            _navigationStore.CurrVMTitleChanged += OnCurrVMTitleChanged;
            TransactionsUtils.TransactionDone += GetCurrentBankAccountBalance;
        }
        
        private async void GetCurrentBankAccountBalance()
        {
            BankAccountUtils bankAccountUtils = new BankAccountUtils();
            AcBalance = await bankAccountUtils.GetBankAccountBalanceUtility(_loggedAccount.Id);
        }
        private void OnCurrVMTitleChanged()
        {
            OnPropertyChanged(nameof(PageTitle));
        }

        private void SendMoney()
        {
            _dialogService.ShowDialog(new SendMoneyDialogView(), new SendMoneyDialogVM(_loggedAccount, _navigationStore));
        }
    }
}
