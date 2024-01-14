using BankingSystem.Model.DataBaseConnection;
using BankingSystem.Model.Entities;
using BankingSystem.Model.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankingSystem.Model.DataServices
{
    public class CustomerDataService : DataServiceBase
    {
        public async Task<UserProfileDetails> GetUserProfileDetails(int customerId)
        {
            UserProfileDetails UserProfileDetails = null;

            var response = await _dbContext.Customers.FindAsync(customerId);
            if (response != null)
            {
                UserProfileDetails = new UserProfileDetails()
                {
                    Name = response.FirstName + " " + response.LastName,
                    Email = response.Email,
                    Phone = response.Phone,
                    Gender = response.Gender,
                    DOB = response.DOB?.ToString(),
                    Address = "Not available"
                };
            }

            return UserProfileDetails;
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

        public async Task<ObservableCollection<CustomerPOCO>> GetAllUsers()
        {
            ObservableCollection<CustomerPOCO> customers = null;
            try
            {
                var response = await _dbContext.Customers.ToListAsync();
                customers = new ObservableCollection<CustomerPOCO>(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
            return customers;
        }
    }
}
