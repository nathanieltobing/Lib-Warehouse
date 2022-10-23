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
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        UserRepository uRepo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userID = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            if (uRepo.checkLogin(userID, password))
            {
                Response.Write("<script>alert('Login Successful');</script>");
               
                Response.Redirect("homepage.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid credentials');</script>");
            }




        }

       
    }
}