using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lib_Warehouses.Model
   
{
    public class user
    {
        private string fullName;
        private string password;
        private string email;
        private string member_id;
        private string dob;
        private string contact_no;
        private string state;
        private string city;
        private string fullAddress;
        private string pincode;
        private string accountStatus;



        public user(string fullName, string password, string email, string member_id, string dob, string contact_no, string state, string city, string fullAddress, string pincode, string accountStatus)
        {
            this.FullName = fullName;
            this.Password = password;
            this.Email = email;
            this.Member_id = member_id;
            this.Dob = dob;
            this.Contact_no = contact_no;
            this.State = state;
            this.City = city;
            this.FullAddress = fullAddress;
            this.Pincode = pincode;
            this.AccountStatus = accountStatus;
        }

        public string FullName { get => fullName; set => fullName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Member_id { get => member_id; set => member_id = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Contact_no { get => contact_no; set => contact_no = value; }
        public string State { get => state; set => state = value; }
        public string City { get => city; set => city = value; }
        public string FullAddress { get => fullAddress; set => fullAddress = value; }
        public string Pincode { get => pincode; set => pincode = value; }
        public string AccountStatus { get => accountStatus; set => accountStatus = value; }
    }
}