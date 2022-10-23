using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lib_Warehouses.View
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; // sign up link button
                    LinkButton3.Visible = false; //logout link button
                    LinkButton7.Visible = false; //hello user link button
                    LinkButton4.Visible = false; //book database
                    LinkButton5.Visible = false; //view books

                    LinkButton6.Visible = true; // admin login link button
                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // publisher management link button
                    LinkButton8.Visible = false; // book inventory link button
                    LinkButton9.Visible = false; // book issuing link button
                    LinkButton10.Visible = false; // member management link button
                }
                else if (Session["role"].Equals("user"))
                {
                    if (Session["status"].Equals("active"))
                    {
                        LinkButton1.Visible = false; // user login link button
                        LinkButton2.Visible = false; // sign up link button
                        LinkButton3.Visible = true; //logout link button
                        LinkButton4.Visible = true; //book database
                        LinkButton5.Visible = true; //view books
                        LinkButton7.Visible = true; //hello user link button
                        LinkButton7.Text = "Hello " + Session["username"].ToString();

                        LinkButton6.Visible = true; // admin login link button
                        LinkButton11.Visible = false; // author management link button
                        LinkButton12.Visible = false; // publisher management link button
                        LinkButton8.Visible = false; // book inventory link button
                        LinkButton9.Visible = false; // book issuing link button
                        LinkButton10.Visible = false; // member management link button

                    }
                    else
                    {
                        LinkButton1.Visible = false; // user login link button
                        LinkButton2.Visible = false; // sign up link button
                        LinkButton3.Visible = true; //logout link button
                        LinkButton4.Visible = false; //book database
                        LinkButton5.Visible = true; //view books
                        LinkButton7.Visible = true; //hello user link button
                        LinkButton7.Text = "Hello " + Session["username"].ToString();

                        LinkButton6.Visible = true; // admin login link button
                        LinkButton11.Visible = false; // author management link button
                        LinkButton12.Visible = false; // publisher management link button
                        LinkButton8.Visible = false; // book inventory link button
                        LinkButton9.Visible = false; // book issuing link button
                        LinkButton10.Visible = false; // member management link button
                    }
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button
                    LinkButton5.Visible = true; //view books
                    LinkButton4.Visible = true; //book database
                    LinkButton3.Visible = true; //logout link button
                    LinkButton7.Visible = true; //hello user link button
                    LinkButton7.Text = "Hello Admin";

                    LinkButton6.Visible = false; // admin login link button
                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // publisher management link button
                    LinkButton8.Visible = false; // book inventory link button
                    LinkButton9.Visible = false; // book issuing link button
                    LinkButton10.Visible = true; // member management link button
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminusermanagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookinventory.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        //logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["fullname"] = null;
            Session["role"] = null;
            Session["status"] = null;

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // sign up link button
            LinkButton3.Visible = false; //logout link button
            LinkButton7.Visible = false; //hello user link button
            LinkButton4.Visible = false; //book database
            

            LinkButton6.Visible = true; // admin login link button
            LinkButton11.Visible = false; // author management link button
            LinkButton12.Visible = false; // publisher management link button
            LinkButton8.Visible = false; // book inventory link button
            LinkButton9.Visible = false; // book issuing link button
            LinkButton10.Visible = false; // member management link button

            Response.Redirect("homepage.aspx");
        }

        // view profile
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }
    }
}