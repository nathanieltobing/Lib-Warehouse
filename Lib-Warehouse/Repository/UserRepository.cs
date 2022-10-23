using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lib_Warehouses.Model;
using Lib_Warehouses.Factory;

namespace Lib_Warehouses.Repository
{
    public class UserRepository : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        
        public void signUp(user User1)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) //check whether the connection is connected to the db or not
                {
                    //if the connection state is closed, we want to open it
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", User1.FullName );
                cmd.Parameters.AddWithValue("@dob", User1.Dob);
                cmd.Parameters.AddWithValue("@contact_no", User1.Contact_no);
                cmd.Parameters.AddWithValue("@email", User1.Email);
                cmd.Parameters.AddWithValue("@state", User1.State);
                cmd.Parameters.AddWithValue("@city", User1.City);
                cmd.Parameters.AddWithValue("@pincode", User1.Pincode);
                cmd.Parameters.AddWithValue("@full_address", User1.FullAddress);
                cmd.Parameters.AddWithValue("@member_id", User1.Member_id);
                cmd.Parameters.AddWithValue("@password", User1.Password);
                cmd.Parameters.AddWithValue("@account_status",User1.AccountStatus);

                cmd.ExecuteNonQuery();
                con.Close();
               
            }
            catch (Exception ex)
            {

                //Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        public bool checkIfUserExisted(string userID)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) //check whether the connection is connected to the db or not
                {
                    //if the connection state is closed, we want to open it
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id = " +
                  "'" + userID + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
            
                return false;
            }
        }

        public bool checkLogin(string userID,string password)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + userID + "' AND password='" + password + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       
                        Session["username"] = dr.GetValue(8).ToString();
                        Session["fullname"] = dr.GetValue(0).ToString();
                        Session["role"] = "user"; //( user itu member)
                        Session["status"] = dr.GetValue(10).ToString();
                    }
                    return true;
                }
                else
                {
                   
                    return false;
                }

            }
            catch (Exception ex)
            {
                // Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        public void deleteUser(string userID)


        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl WHERE member_id='" + userID + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
               
               

            }
            catch (Exception ex)
            {
                
            }
        }

        public void updateUser(string userID,string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + userID + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
               


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}