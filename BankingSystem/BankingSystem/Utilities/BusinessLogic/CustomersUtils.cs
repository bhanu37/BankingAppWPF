using BankingSystem.Model.DataServices;
using BankingSystem.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Utilities.BusinessLogic
{
    public class CustomersUtils
    {
        public async Task<ObservableCollection<Users>> GetAllUsersUtility()
        {
            var allUsers = new ObservableCollection<Users>();
            CustomerDataService customerDataService = new CustomerDataService();
            var response = await customerDataService.GetAllUsers();

            if(response != null)
            {
                allUsers = new ObservableCollection<Users>(response.Select(res => new Users() { UserId = res.CustomerId, Email = res.Email, Name = res.FirstName + " " + res.LastName }));
            }
            return allUsers;
        }
    }
}
