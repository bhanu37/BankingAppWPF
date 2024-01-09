using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model.Entities
{
    public class CustomerProfile : EntityPropertyChanged
    {
        private string _name;
        private string _email;
        private string _phone;
        private string _gender;
        private string _dob;
        private string _address;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged(nameof(Gender)); }
        }

        public string DOB
        {
            get { return _dob; }
            set { _dob = value; OnPropertyChanged(nameof(DOB)); }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }
    }
}
