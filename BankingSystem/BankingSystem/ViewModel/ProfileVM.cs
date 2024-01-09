using BankingSystem.Model.DataServices;
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

namespace BankingSystem.ViewModel
{
    public class ProfileVM : ViewModelBase
    {
        private LoggedAccount _loggedAccount;
        private CustomerProfile _customerProfile;
        private NavigationStore _navigationStore;
        private IDialogService _dialogService;

        public string Header => "Profile Page";
        public ICommand UpdateProfileCMD { get; set; }

        public CustomerProfile CustomerProfile
        {       
            get { return _customerProfile; }
            set { _customerProfile = value; OnPropertyChanged(nameof(CustomerProfile)); }
        }


        public ProfileVM(LoggedAccount loggedAccount, NavigationStore navigationStore)
        {
            _loggedAccount = loggedAccount;
            _dialogService = new OperationalDialogs();
            _navigationStore = navigationStore;
            UpdateProfileCMD = new FunctionalCommand(UpdateProfile);
            LoadData();
        }

        private void UpdateProfile()
        {
            _dialogService.ShowDialog(new UpdateProfileDialogView(), new UpdateProfileDialogVM(_loggedAccount, _navigationStore));
        }


        private async void LoadData()
        {
            CustomerDataService customerDataService = new CustomerDataService();
            CustomerProfile = await customerDataService.GetCustomerProfile(_loggedAccount.Id);
        }

        ~ProfileVM() { }
    }
}
