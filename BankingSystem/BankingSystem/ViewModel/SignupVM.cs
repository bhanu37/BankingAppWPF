using BankingSystem.Model.Entities;
using BankingSystem.Utilities.Commands;
using BankingSystem.Utilities.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankingSystem.ViewModel
{
    public class SignupVM : ViewModelBase
    {
        private NavigationStore _navigationStore { get; set; }

        private string _firstName;
        private string _lastName;
        private string _emailOrAccount;
        private string _password;

        public string Header => "Sign Up";
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName = value; 
                OnPropertyChanged(nameof(LastName));    
            }
        }
        public string EmailOrAccount
        {
            get { return _emailOrAccount; }
            set
            {
                _emailOrAccount = value;
                OnPropertyChanged(nameof(EmailOrAccount));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand NavigateToLogin { get; set; }
        public ICommand Signup { get; set; }

        public SignupVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            NavigateToLogin = new NavigationCommand(_navigationStore, () => new LoginVM(navigationStore));
            Signup = new FunctionalCommand(UserSignUp);
        }

        private void UserSignUp()
        {
            //signup success
            LoggedAccount loggedAccount = new LoggedAccount() { Name = _emailOrAccount.Substring(0, _emailOrAccount.IndexOf("@")), Email = _emailOrAccount };
            _navigationStore.CurrentVM = new HomeVM(loggedAccount);
        }
    }
}
