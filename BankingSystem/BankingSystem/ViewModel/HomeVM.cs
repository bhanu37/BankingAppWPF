using BankingSystem.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ViewModel
{
    public class HomeVM : ViewModelBase
    {
        public string Header => "Home Page";

		private string _userName;
		private string _email;


        public string UserName
		{
			get { return _userName; }
			set 
			{ 
				_userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}

		public string Email
		{
			get { return _email; }
			set 
			{ 
				_email = value; 
				OnPropertyChanged(nameof(Email));
			}
		}

        public HomeVM(LoggedAccount loggedAccount)
        {
			UserName = loggedAccount.Name;
			Email = loggedAccount.Email;
        }
	}
}
