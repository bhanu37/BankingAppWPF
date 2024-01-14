using BankingSystem.Model.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.DataServices
{
    public class DataServiceBase
    {
        protected BankingSystemDbContextFactory _contextFactory;
        protected BankingSystemDbContext _dbContext;

        public DataServiceBase()
        {
            _contextFactory = new BankingSystemDbContextFactory();
            _dbContext = _contextFactory.CreateDbContext();
        }
    }
}
