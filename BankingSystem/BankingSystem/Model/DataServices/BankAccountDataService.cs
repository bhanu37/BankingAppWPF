﻿using BankingSystem.Model.DataBaseConnection;
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
using System.Linq.Expressions;

namespace BankingSystem.Model.DataServices
{
    public class BankAccountDataService : DataServiceBase
    {
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

        public async Task<bool> UpdateBankAccount(BankAccountPOCO bankAccount)
        {
            try
            {
                var response = await _dbContext.BankAccounts.FindAsync(bankAccount.AccountNumber);
                if (response != null)
                {
                    response.Balance = bankAccount.Balance;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); 
            }
            return false;
        }
    }
}
