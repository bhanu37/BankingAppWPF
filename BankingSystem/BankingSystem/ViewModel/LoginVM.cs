﻿using BankingSystem.Model.DataServices;
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
    public class LoginVM : ViewModelBase
    {
        private NavigationStore _navigationStore;

        private string _emailOrAccount;
        private string _password;

        public string Header => "Log In";
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


        public ICommand NavigateToSignup {  get; set; }
        public ICommand Login {  get; set; }

        public LoginVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            NavigateToSignup = new NavigationCommand(_navigationStore, () => new SignupVM(navigationStore));
            Login = new FunctionalCommand(UserLogIn);
        }

        private async void UserLogIn()
        {
            SignupDataService signupDataService = new SignupDataService();
            LoggedAccount loggedAccount = await signupDataService.CustomerSignin(EmailOrAccount, Password);

            if(loggedAccount != null)
            {
                //login success
                _navigationStore.CurrentVM = new HomeVM();
                _navigationStore.NavSideBarVM = new NavigationSideBarVM(loggedAccount, _navigationStore);
                _navigationStore.TopBarVM = new TopBarVM(loggedAccount ,_navigationStore);
                _navigationStore.CurrVMTitle = "Home";
            }
        }
    }
}
