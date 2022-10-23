using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lib_Warehouses.Model
{
    public class admin
    {
        private string username;
        private string password;
        private string fullName;
       
        public admin(string username, string password, string fullName)
        {
            this.Username = username;
            this.Password = password;
            this.FullName = fullName;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FullName { get => fullName; set => fullName = value; }
    }
}