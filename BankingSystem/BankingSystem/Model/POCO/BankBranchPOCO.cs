using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.POCO
{
    public class BankBranchPOCO
    {
        #region Columns
        [Key]
        public int BankBranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }
        public string BranchManager { get; set; }
        public string IFSCCode { get; set; }
        #endregion

        #region Relations
        public List<BankAccountPOCO>? BankAccountPOCO { get; set; }
        #endregion

    }
}
