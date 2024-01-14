using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.POCO
{
    public class TransactionPOCO
    {
        #region Columns
        [Key]
        public int TransactionId { get; set; }
        public double Ammount { get; set; }
        public DateTime TrasactionTime { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        #endregion

        #region Relations
        public CustomerPOCO FromAccount { get; set; }
        public CustomerPOCO ToAccount { get; set; }
        #endregion
    }
}
