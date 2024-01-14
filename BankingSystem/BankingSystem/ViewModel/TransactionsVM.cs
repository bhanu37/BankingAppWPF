using BankingSystem.Model.DataServices;
using BankingSystem.Model.Entities;
using BankingSystem.Model.POCO;
using BankingSystem.Utilities.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ViewModel
{
    public class TransactionsVM : ViewModelBase
    {
        private LoggedAccount _loggedAccount;
        private ObservableCollection<TransactionPOCO> _transactions;
        private TransactionsUtils _transactionsUtils;

        public ObservableCollection<TransactionPOCO> Transactions
        {
            get { return _transactions; }
            set { _transactions = value; OnPropertyChanged(nameof(Transactions)); }
        }


        public string Header => "Transaction Page";

        public TransactionsVM(LoggedAccount loggedAccount)
        {
            _loggedAccount = loggedAccount;
            _transactionsUtils = new TransactionsUtils();
            LoadData();
        }

        private async void LoadData()
        {
            Transactions = await _transactionsUtils.GetAllTransactionsOfUserUtility(_loggedAccount.Id);
        }
    }
}
