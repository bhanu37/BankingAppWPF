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
    public class BankBranchesDataService
    {
        private BankingSystemDbContextFactory _contextFactory;
        private BankingSystemDbContext _dbContext;

        public BankBranchesDataService()
        {
            _contextFactory = new BankingSystemDbContextFactory();
            _dbContext = _contextFactory.CreateDbContext();
        }


        public async Task<ObservableCollection<BankBranchPOCO>> GetAllBankBranches()
        {
            var response = new ObservableCollection<BankBranchPOCO>();
            try
            {
                var res = await _dbContext.BankBranches.ToListAsync();
                response = new ObservableCollection<BankBranchPOCO>(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return response;
        }

        public async Task<BankBranchPOCO> GetBankBranchById(int? branchId)
        {
            BankBranchPOCO bankBranchPOCO = new BankBranchPOCO();
            try
            {
                var response = await _dbContext.BankBranches.FindAsync(branchId);
                if (response != null)
                    bankBranchPOCO = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return bankBranchPOCO;
        }
    }
}
