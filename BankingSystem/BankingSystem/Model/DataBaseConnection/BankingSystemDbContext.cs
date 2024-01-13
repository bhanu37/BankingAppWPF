using BankingSystem.Model.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.DataBaseConnection
{
    public class BankingSystemDbContext : DbContext
    {
        #region DB Sets
        public DbSet<CustomerPOCO> Customers { get; set; }
        public DbSet<AddressPOCO> Addresses { get; set; }
        public DbSet<BankAccountPOCO> BankAccounts { get; set; }
        public DbSet<BankBranchPOCO> BankBranches { get; set; }
        #endregion

        #region Ctor
        public BankingSystemDbContext(DbContextOptions<BankingSystemDbContext> options) : base(options) { }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPOCO>().HasIndex(p => p.Email).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
