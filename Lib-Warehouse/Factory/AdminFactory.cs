using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lib_Warehouses.Model;

namespace Lib_Warehouses.Factory
{
    public class AdminFactory
    {

        public admin getAdmin(string username, string password, string fullName)
        {
            return new admin(username, password, fullName);
        }
    }
}