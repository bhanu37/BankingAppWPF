using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.Entities
{
    public class BankUser
    {
        public int UserId { get; set; }
        public int BankAccountNumber { get; set; }
        public string Email { get; set; }
    }
}
