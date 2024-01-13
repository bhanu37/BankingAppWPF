using BankingSystem.Model.DataServices;
using BankingSystem.Model.Entities;
using BankingSystem.Model.POCO;
using BankingSystem.Utilities.BusinessLogic;
using BankingSystem.Utilities.Commands;
using BankingSystem.Utilities.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankingSystem.ViewModel.PopupsAndDialogsVM
{
    public class CreateUpdateBankAccountDialogVM : ViewModelBase
    {
        public string Header => "Create or Update Bank Account";

        private LoggedAccount _loggedAccount;
        private NavigationStore _navigationStore;
        private BankAccountDataService _bankAccountDataService;
        private BankBranchesDataService _bankBranchesDataService;
        private BankAccountPOCO _bankAccount;
        private ObservableCollection<BankBranchPOCO> _bankBranches;
        private BankBranchPOCO _selectedBankBranch;
        private string _selectedAccountType;

        public ICommand AddBankAccountCMD { get; set; }
        public BankAccountPOCO BankAccount
        {
            get { return _bankAccount; }
            set { _bankAccount = value; OnPropertyChanged(nameof(BankAccount)); }
        }

        public string SelectedAccountType
        {
            get { return _selectedAccountType; }
            set { _selectedAccountType = value; OnPropertyChanged(nameof(SelectedAccountType)); }
        }
        public ObservableCollection<BankBranchPOCO> BankBranches
        {
            get { return _bankBranches; }
            set { _bankBranches = value; OnPropertyChanged(nameof(BankBranches)); }
        }
        public BankBranchPOCO SelectedBankBranch
        {
            get { return _selectedBankBranch; }
            set { _selectedBankBranch = value; OnPropertyChanged(nameof(SelectedBankBranch)); }
        }

        public List<string> BankAccountTypes => new List<string>() { "Saving Account", "Salary Account", "Current Account" };

        public CreateUpdateBankAccountDialogVM(LoggedAccount loggedAccount, NavigationStore navigationStore)
        {
            _loggedAccount = loggedAccount;
            _navigationStore = navigationStore;
            _bankAccountDataService = new BankAccountDataService();
            _bankBranchesDataService = new BankBranchesDataService();
            AddBankAccountCMD = new FunctionalCommand(AddBankAccount);

            GetAllBankBranches();
            SelectedAccountType = BankAccountTypes[0];
        }


        private async void GetAllBankBranches()
        {
            BankBranches = await _bankBranchesDataService.GetAllBankBranches();
        }

        private async void AddBankAccount()
        {
            BankAccountUtils bankAccountUtils = new BankAccountUtils();
            BankAccount = bankAccountUtils.GetBankAccpountToAdd(_loggedAccount.Id, SelectedAccountType, SelectedBankBranch.BankBranchId);
            bool response = await _bankAccountDataService.AddBankAccount(BankAccount);
            _navigationStore.CurrentVM = new ProfileVM(_loggedAccount, _navigationStore);
        }
    }
}
