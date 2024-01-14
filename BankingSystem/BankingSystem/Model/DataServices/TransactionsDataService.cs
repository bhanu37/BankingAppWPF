using BankingSystem.Model.DataBaseConnection;
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
    public class TransactionsDataService : DataServiceBase
    {
        public async Task<ObservableCollection<TransactionPOCO>> GetAllTransactionByAccountId(int accountNumber)
        {
            ObservableCollection<TransactionPOCO> transactions = null;
            try
            {
                var response = await _dbContext.Transactions.Where(t => t.FromAccountId == accountNumber || t.ToAccountId == accountNumber).ToListAsync();
                transactions = new ObservableCollection<TransactionPOCO>(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return transactions;
        }

        public async Task<bool> AddTransaction(TransactionPOCO transaction)
        {
            try
            {
                var res = await _dbContext.Transactions.AddAsync(transaction);
                await _dbContext.SaveChangesAsync();
                if (res != null)
                {
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
