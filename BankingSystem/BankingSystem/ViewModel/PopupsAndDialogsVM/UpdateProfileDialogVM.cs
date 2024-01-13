using BankingSystem.Model.DataServices;
using BankingSystem.Model.Entities;
using BankingSystem.Model.POCO;
using BankingSystem.Utilities.Commands;
using BankingSystem.Utilities.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankingSystem.ViewModel.PopupsAndDialogsVM
{
    public class UpdateProfileDialogVM : ViewModelBase
    {
        private LoggedAccount _loggedAccount;
        private CustomerPOCO _customer;
        private CustomerDataService _customerDataService;
        private NavigationStore _navigationStore;



        public string Header => "Update Profile";
        public CustomerPOCO Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged(nameof(Customer)); }
        }

        public ICommand UpdateCustomer { get; set; }


        public UpdateProfileDialogVM(LoggedAccount loggedAccount, NavigationStore navigationStore)
        {
            _loggedAccount = loggedAccount;
            _navigationStore = navigationStore;
            _customerDataService = new CustomerDataService();
            UpdateCustomer = new FunctionalCommand(UpdateCustomerData);
            LoadData();
        }

        private void UpdateCustomerData()
        {
            Customer.DOB = DateTime.Now;    
            _customerDataService.UpdateCustomerData(Customer);
            _navigationStore.CurrentVM = new ProfileVM(_loggedAccount, _navigationStore);
        }

        private async void LoadData()
        {
            Customer = await _customerDataService.GetCustomerById(_loggedAccount.Id);
        }

        ~UpdateProfileDialogVM() { }
    }
}
