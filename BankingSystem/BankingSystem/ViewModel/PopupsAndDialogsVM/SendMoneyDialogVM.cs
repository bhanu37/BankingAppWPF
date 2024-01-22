using BankingSystem.Model.Entities;
using BankingSystem.Utilities.BusinessLogic;
using BankingSystem.Utilities.Commands;
using BankingSystem.Utilities.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BankingSystem.ViewModel.PopupsAndDialogsVM
{
    public class SendMoneyDialogVM : ViewModelBase
    {
        private LoggedAccount _loggedAccount;
        private NavigationStore _navigationStore;

        public string Header => "Send Money";
        public ICommand SendMoneyCMD { get; set; }

        private double _amountToPay;
        private ObservableCollection<Users> _users;
        private Users _selectedUser;

        public double AmountToPay
        {
            get { return _amountToPay; }
            set { _amountToPay = value; OnPropertyChanged(nameof(AmountToPay)); }
        }
        public ObservableCollection<Users> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged(nameof(Users)); }
        }
        public Users SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; OnPropertyChanged(nameof(SelectedUser)); }
        }

        public SendMoneyDialogVM(LoggedAccount loggedAccount, NavigationStore navigationStore)
        {
            _loggedAccount = loggedAccount;
            _navigationStore = navigationStore;
            SendMoneyCMD = new FunctionalCommand(SendMoney);
            LoadData();
        }

        private async void LoadData()
        {
            CustomersUtils customersUtils = new CustomersUtils();
            var bankUsers = await customersUtils.GetAllUsersUtility();
            Users = new ObservableCollection<Users>(bankUsers.Where(user =>  user.UserId != _loggedAccount.Id));
        }

        private async void SendMoney()
        {
            TransactionsUtils transactionsUtils = new TransactionsUtils();
            var res = await transactionsUtils.MakeTransactionUtility(_loggedAccount.Id, SelectedUser.UserId, AmountToPay);
            if(res)
            {
                _navigationStore.CurrentVM = new TransactionsVM(_loggedAccount);
                _navigationStore.CurrVMTitle = "Transactions";
            }
        }
    }
}
