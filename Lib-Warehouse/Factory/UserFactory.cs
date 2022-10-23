using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lib_Warehouses.Model;

namespace Lib_Warehouses.Factory
{
    public class UserFactory
    {
       public user getUser(string fullName, string password, string email, string member_id, string dob, string contact_no, string state, string city, string fullAddress, string pincode, string accountStatus)
        {
            return new user(fullName,password,email,member_id,dob,contact_no,state,city,fullAddress,pincode,accountStatus);
        }


    }
}