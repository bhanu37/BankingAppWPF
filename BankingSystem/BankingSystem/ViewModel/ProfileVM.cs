using BankingSystem.Model.DataServices;
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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace BankingSystem.ViewModel
{
    public class ProfileVM : ViewModelBase
    {
        private LoggedAccount _loggedAccount;
        private UserProfileDetails _UserProfileDetails;
        private NavigationStore _navigationStore;
        private IDialogService _dialogService;
        private UserBankAccountDetails _userBankAccount;
        private bool _bankAccountExist;

        public ICommand UpdateProfileCMD { get; set; }
        public ICommand CreateBankAccountCMD { get; set; }

        public UserProfileDetails UserProfileDetails
        {       
            get { return _UserProfileDetails; }
            set { _UserProfileDetails = value; OnPropertyChanged(nameof(UserProfileDetails)); }
        }
        public UserBankAccountDetails UserBankAccount
        {
            get { return _userBankAccount; }
            set { _userBankAccount = value; OnPropertyChanged(nameof(UserBankAccount)); }
        }
        public bool CreateAccountCommandVisibility => !BankAccountExist;
        public bool BankAccountExist
        {
            get { return _bankAccountExist; }
            set 
            { 
                _bankAccountExist = value; 
                OnPropertyChanged(nameof(BankAccountExist));  
                OnPropertyChanged(nameof(CreateAccountCommandVisibility));  
            }
        }

        public ProfileVM(LoggedAccount loggedAccount, NavigationStore navigationStore)
        {
            _loggedAccount = loggedAccount;
            _dialogService = new OperationalDialogs();
            _navigationStore = navigationStore;
            UpdateProfileCMD = new FunctionalCommand(UpdateProfile);
            CreateBankAccountCMD = new FunctionalCommand(CreateUpdateBankAccount);
            LoadData();
        }

        private void CreateUpdateBankAccount()
        {
            _dialogService.ShowDialog(new CreateUpdateBankAccountDialogView(), new CreateUpdateBankAccountDialogVM(_loggedAccount, _navigationStore));
        }

        private void UpdateProfile()
        {
            _dialogService.ShowDialog(new UpdateProfileDialogView(), new UpdateProfileDialogVM(_loggedAccount, _navigationStore));
        }


        private async void LoadData()
        {
            CustomerDataService customerDataService = new CustomerDataService();
            UserProfileDetails = await customerDataService.GetUserProfileDetails(_loggedAccount.Id);
            UserProfileDetails.DOB = DateTime.Now.ToString();

            BankAccountUtils bankAccountUtils = new BankAccountUtils();
            UserBankAccount = await bankAccountUtils.GetUserBankAccountDetails(_loggedAccount.Id);
            if(UserBankAccount != null)
            {
                BankAccountExist = true;
            }
            else
            {
                BankAccountExist = false;
            }
        }

        ~ProfileVM() { }
    }
}
