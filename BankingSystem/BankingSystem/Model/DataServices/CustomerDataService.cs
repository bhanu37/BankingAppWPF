using BankingSystem.Model.DataBaseConnection;
using BankingSystem.Model.Entities;
using BankingSystem.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.DataServices
{
    public class CustomerDataService
    {
        private BankingSystemDbContext _dbContext;
        private BankingSystemDbContextFactory _contextFactory;

        public CustomerDataService()
        {
            _contextFactory = new BankingSystemDbContextFactory();
            _dbContext = _contextFactory.CreateDbContext();
        }

        public async Task<CustomerProfile> GetCustomerProfile(int customerId)
        {
            CustomerProfile customerProfile = null;

            var response = await _dbContext.Customers.FindAsync(customerId);
            if (response != null)
            {
                customerProfile = new CustomerProfile()
                {
                    Name = response.FirstName + " " + response.LastName,
                    Email = response.Email,
                    Phone = response.Phone,
                    Gender = response.Gender,
                    DOB = response.DOB?.ToString(),
                    Address = "Not available"
                };
            }

            return customerProfile;
        }
        
        public async Task<CustomerPOCO> GetCustomerById(int customerId)
        {
            var response = await _dbContext.Customers.FindAsync(customerId);
            return response != null ? response : new CustomerPOCO();
        }

        public async void UpdateCustomerData(CustomerPOCO customer)
        {
            var response = await _dbContext.Customers.FindAsync(customer.CustomerId);
            if (response != null)
            {
                response.FirstName = customer.FirstName;
                response.LastName = customer.LastName;
                response.Email = customer.Email;
                response.Phone = customer.Phone;
                response.DOB = customer.DOB;
                response.Gender = customer.Gender;

                _dbContext.SaveChanges();
            }
        }
    }
}
