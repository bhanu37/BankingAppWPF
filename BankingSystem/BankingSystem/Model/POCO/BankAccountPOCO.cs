using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.POCO
{
    public class BankAccountPOCO
    {
        #region Columns
        [Key]
        public int AccountNumber { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }
        public double InterestRate {  get; set; }
        public double Balance { get; set; }
        public int CustomerId { get; set; }
        public int? BranchId { get; set; }
        #endregion

        #region Relations
        public CustomerPOCO Customer { get; set; }
        public BankBranchPOCO Branch { get; set; }
        #endregion

    }
}
