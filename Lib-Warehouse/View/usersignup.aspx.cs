using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lib_Warehouses.Factory;
using Lib_Warehouses.Model;
using Lib_Warehouses.Repository;

namespace Lib_Warehouses.View
{
    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        UserFactory uFactory = new UserFactory();
        UserRepository uRepo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //sign up button click event is triggered
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string fullName = TextBox1.Text.Trim();
            string userID = TextBox8.Text.Trim(); ;
            string dob = TextBox2.Text.Trim();
            string contactNo = TextBox3.Text.Trim();
            string email = TextBox4.Text.Trim();
            string state = DropDownList1.SelectedItem.Value;
            string city = TextBox6.Text.Trim();
            string pincode = TextBox7.Text.Trim();
            string fullAddress = TextBox5.Text.Trim();
            string password = TextBox9.Text.Trim();
            string accountStatus = "pending";

            user User1 = uFactory.getUser(fullName, password, email, userID, dob, contactNo
                , state, city, fullAddress, pincode, accountStatus);

            

            if (uRepo.checkIfUserExisted(User1.Member_id))
            {
                Response.Write("<script>alert('Id already Existed');</script>");
            }
            else
            {
                  uRepo.signUp(User1);
                  Response.Write("<script>alert('Sign up successful.');</script>");
                  Response.Redirect("userlogin.aspx");
                
            }

        }


    }
}