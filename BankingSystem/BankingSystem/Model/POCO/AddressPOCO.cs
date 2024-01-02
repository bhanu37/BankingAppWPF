using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.POCO
{
    public class AddressPOCO
    {
        #region Columns
        [Key]
        public int AddressId { get; set; }                      // Primary Key
        public string City {  get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public int CustomerId { get; set; }
        #endregion

        #region Relations
        public CustomerPOCO Customer { get; set; }
        #endregion
    }
}
