using BankingSystem.Model.DataBaseConnection;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Model.POCO;
using BankingSystem.Model.Entities;
using System.Windows;

namespace BankingSystem.Model.DataServices
{
    public class BankAccountDataService
    {
        private BankingSystemDbContextFactory _contextFactory;
        private BankingSystemDbContext _dbContext;

        public BankAccountDataService()
        {
            _contextFactory = new BankingSystemDbContextFactory();
            _dbContext = _contextFactory.CreateDbContext();
        }

        public async Task<bool> AddBankAccount(BankAccountPOCO bankAccount)
        {
            try
            {
                var entity = await _dbContext.BankAccounts.AddAsync(bankAccount);
                await _dbContext.SaveChangesAsync();
                if (entity.Entity != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return false;
        }

        public async Task<BankAccountPOCO> GetBankAccountByUserId(int userId)
        {
            BankAccountPOCO bankAccountPOCO;
            try
            {
                var response = await _dbContext.BankAccounts.FirstOrDefaultAsync(account => account.CustomerId == userId);
                if (response != null)
                {
                    bankAccountPOCO = response;
                    return bankAccountPOCO;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return null;
        }
    }
}
