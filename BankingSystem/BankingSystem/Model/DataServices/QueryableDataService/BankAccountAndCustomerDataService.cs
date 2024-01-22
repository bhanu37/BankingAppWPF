using BankingSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;

namespace BankingSystem.Model.DataServices.QueryableDataService
{
    public class BankAccountAndCustomerDataService : DataServiceBase
    {
        public BankAccountAndCustomerDataService():base() { }
        public async Task<ObservableCollection<BankUser>> GetAllBankUser()
        {
            ObservableCollection<BankUser> user = null;
            try
            {
                var query = from customer in _dbContext.Customers
                            join account in _dbContext.BankAccounts on customer.CustomerId equals account.CustomerId
                            select new BankUser
                            {
                                UserId = customer.CustomerId,
                                BankAccountNumber = account.AccountNumber,
                                Email = customer.Email
                            };
                var response = await query.ToListAsync();
                user = new ObservableCollection<BankUser>(response);    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return user;
        }
    }
}
