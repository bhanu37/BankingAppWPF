using BankingSystem.Model.DataBaseConnection;
using BankingSystem.Model.Entities;
using BankingSystem.Model.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankingSystem.Model.DataServices
{
    public class SignupDataService : DataServiceBase
    {
        public async Task<LoggedAccount> CustomerSignup(string fName, string lName, string email, string password)
        {
            CustomerPOCO customerPOCO = new CustomerPOCO() { FirstName = fName, LastName = lName, Email = email, Password = password };
            LoggedAccount loggedAccount = null;
            try
            {
                var entity = await _dbContext.Customers.AddAsync(customerPOCO);
                await _dbContext.SaveChangesAsync();
                var user = entity.Entity;
                loggedAccount = new LoggedAccount() { Id = user.CustomerId, Name = user.FirstName + " " + user.LastName, Email = user.Email };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return loggedAccount;
        }

        public async Task<LoggedAccount> CustomerSignin(string email, string password)
        {
            LoggedAccount loggedAccount = null;

            try
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(cost =>  cost.Email == email && cost.Password == password);
                loggedAccount = new LoggedAccount() { Id = customer.CustomerId, Name = customer.FirstName + " " + customer.LastName, Email = customer.Email };
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            return loggedAccount;
        }
    }
}
