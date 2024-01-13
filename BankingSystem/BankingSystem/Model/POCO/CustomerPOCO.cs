using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.POCO
{
    public class CustomerPOCO
    {
        #region Columns
        [Key]
        public int CustomerId { get; set; }                     // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }  
        public string? Phone { get; set; }
        public string Password { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        #endregion

        #region Relations
        public AddressPOCO AddressPOCO { get; set; }
        public BankAccountPOCO BankAccountPOCO { get; set;}
        #endregion
    }
}
