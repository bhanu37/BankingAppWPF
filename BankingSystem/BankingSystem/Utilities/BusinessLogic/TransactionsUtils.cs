using BankingSystem.Model.DataServices;
using BankingSystem.Model.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankingSystem.Utilities.BusinessLogic
{
    public class TransactionsUtils
    {
        public async Task<ObservableCollection<TransactionPOCO>> GetAllTransactionsOfUserUtility(int userId)
        {
            BankAccountDataService accountDataService = new BankAccountDataService();
            TransactionsDataService transactionsDataService = new TransactionsDataService();
            ObservableCollection<TransactionPOCO> transactions = new ObservableCollection<TransactionPOCO>();

            var account = await accountDataService.GetBankAccountByUserId(userId);

            transactions = await transactionsDataService.GetAllTransactionByAccountId(account.AccountNumber);

            return transactions;
        }

        public async Task<bool> MakeTransactionUtility(int fromUserId, int toUserId, double amount)
        {
            BankAccountDataService bankAccountDataService = new BankAccountDataService();
            TransactionsDataService tranactionsDataService = new TransactionsDataService();
            
            var user1 = await bankAccountDataService.GetBankAccountByUserId(fromUserId);
            var user2 = await bankAccountDataService.GetBankAccountByUserId(toUserId);

            if(user1 == null)
            {
                MessageBox.Show("You don't have bank account");
                return false;
            }
            else if (user2 == null)
            {
                MessageBox.Show("Reciever don't have bank account");
                return false;
            }
            else if(amount > user1.Balance)
            {
                MessageBox.Show("Insuficient balance");
                return false;
            }

            user1.Balance -= amount; 
            user2.Balance += amount;

            if(await bankAccountDataService.UpdateBankAccount(user1))
            {
                if(await bankAccountDataService.UpdateBankAccount(user2))
                {
                    var transaction = new TransactionPOCO()
                    {
                        Ammount = amount,
                        FromAccountId = user1.AccountNumber,
                        ToAccountId = user2.AccountNumber,
                        TrasactionTime = DateTime.Now
                    };

                    if (await tranactionsDataService.AddTransaction(transaction))
                    { 
                        return true; 
                    }
                    else
                    {
                        user1.Balance += amount;
                        user2.Balance -= amount;
                        await bankAccountDataService.UpdateBankAccount(user1);
                        await bankAccountDataService.UpdateBankAccount(user2);
                    }
                }
                else
                {
                    user1.Balance += amount;
                    await bankAccountDataService.UpdateBankAccount(user1);
                }
            }
            return false;
        }
    }
}
