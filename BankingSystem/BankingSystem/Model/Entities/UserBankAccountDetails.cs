using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.Entities
{
    public class UserBankAccountDetails
    {
        public int AccountNumber { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string CreationDate { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }
        public string BranchManager { get; set; }
        public string IFSCCode { get; set; }
        public double InterestRate { get; set; }
        public double Balance { get; set; } 
    }
}
