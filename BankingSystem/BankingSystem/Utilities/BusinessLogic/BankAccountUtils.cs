using BankingSystem.Model.DataServices;
using BankingSystem.Model.DataServices.QueryableDataService;
using BankingSystem.Model.Entities;
using BankingSystem.Model.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace BankingSystem.Utilities.BusinessLogic
{
    public class BankAccountUtils
    {
        public BankAccountPOCO GetBankAccpountToAdd(int id, string selectedAccountType, int bankBranchId)
        {
            BankAccountPOCO bankAccount = new BankAccountPOCO()
            {
                Type = selectedAccountType,
                CreationDate = DateTime.Now,
                Status = true,
                InterestRate = 2.5,
                Balance = 5000,
                CustomerId = id,
                BranchId = bankBranchId
            };

            return bankAccount;
        }

        public async Task<UserBankAccountDetails> GetUserBankAccountDetails(int id)
        {
            UserBankAccountDetails bankAccountDetails;
            BankAccountDataService bankAccountDataService = new BankAccountDataService();
            BankBranchesDataService bankBranchesDataService = new BankBranchesDataService();

            BankAccountPOCO bankAccount = await bankAccountDataService.GetBankAccountByUserId(id);

            if (bankAccount == null)
            {
                return null;
            }

            BankBranchPOCO bankBranch = await bankBranchesDataService.GetBankBranchById(bankAccount.BranchId);

            bankAccountDetails = new UserBankAccountDetails()
            {
                AccountNumber = bankAccount.AccountNumber,
                Status = bankAccount.Status ? "Active" : "Inactive",
                Type = bankAccount.Type,
                CreationDate = bankAccount.CreationDate.ToString(),
                BranchName = bankBranch.BranchName,
                BranchLocation = bankBranch.BranchLocation,
                BranchManager = bankBranch.BranchManager,
                IFSCCode = bankBranch.IFSCCode,
                InterestRate = bankAccount.InterestRate,
                Balance = bankAccount.Balance
            };
            return bankAccountDetails;
        }

        public async Task<ObservableCollection<BankUser>> GetAllUserEmailsAndAccountNumber()
        {
            BankAccountAndCustomerDataService bankAccountAndCustomerDataService = new BankAccountAndCustomerDataService();
            var bankUsers = await bankAccountAndCustomerDataService.GetAllBankUser();
            return bankUsers;
        }

        public async Task<double> GetBankAccountBalanceUtility(int userId)
        {
            BankAccountDataService bankAccountDataService = new BankAccountDataService();
            var userBankAccount = await bankAccountDataService.GetBankAccountByUserId(userId);

            if(userBankAccount != null)
            {
                return userBankAccount.Balance;
            }

            return 0;
        }
    }
}
