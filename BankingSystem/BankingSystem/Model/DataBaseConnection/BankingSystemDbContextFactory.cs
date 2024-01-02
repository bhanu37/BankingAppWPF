using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.DataBaseConnection
{
    public class BankingSystemDbContextFactory : IDesignTimeDbContextFactory<BankingSystemDbContext>
    {
        private readonly string ConnectionString = @"Server=QUANTUM; Database=BankingSystemDB;"
                                                    + "Integrated Security=true; TrustServerCertificate=true;";
        public BankingSystemDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<BankingSystemDbContext>();
            options.UseSqlServer(ConnectionString);
            return new BankingSystemDbContext(options.Options);
        }
    }
}
