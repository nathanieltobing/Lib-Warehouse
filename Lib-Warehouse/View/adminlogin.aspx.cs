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
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        AdminFactory aFactory = new AdminFactory();
        AdminRepository aRepo = new AdminRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();
            admin Admin1 = aFactory.getAdmin(username, password,"");


            if (aRepo.checkLogin(Admin1))
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