using BankingSystem.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Utilities.Stores
{
    public class LoggedAccountStore
    {
        private LoggedAccount _currentAccount;

        public event Action CurrentLoggedAccountChanged;

        public bool isLoggedIn => CurrentAccount != null;
        public LoggedAccount CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                _currentAccount = value;
                CurrentLoggedAccountChanged?.Invoke();
            }
        }

        public void Logout()
        {
            CurrentAccount = null;
        }
    }
}
