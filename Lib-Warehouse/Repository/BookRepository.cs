using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Lib_Warehouses.Factory;
using Lib_Warehouses.Model;

namespace Lib_Warehouses.Repository
{
    public class BookRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public bool checkIfBookExist(string bookID,string bookName)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + bookID + "' OR book_name='" + bookName + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
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

        public void insertBook(Book book1)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
                cmd.Parameters.AddWithValue("@book_id", book1.BookID);
                cmd.Parameters.AddWithValue("@book_name", book1.BookName);
                cmd.Parameters.AddWithValue("@genre", book1.Genre);
                cmd.Parameters.AddWithValue("@author_name", book1.AuthorName);
                cmd.Parameters.AddWithValue("@publisher_name", book1.PublisherName);
                cmd.Parameters.AddWithValue("@publish_date", book1.PublishDate);
                cmd.Parameters.AddWithValue("@language", book1.Language);
                cmd.Parameters.AddWithValue("@edition", book1.Edition);
                cmd.Parameters.AddWithValue("@book_cost", book1.BookCost);
                cmd.Parameters.AddWithValue("@no_of_pages", book1.NoPages);
                cmd.Parameters.AddWithValue("@book_description", book1.BookDesc);
                cmd.Parameters.AddWithValue("@actual_stock", book1.ActualStock);
                cmd.Parameters.AddWithValue("@current_stock", book1.CurrStock);
                cmd.Parameters.AddWithValue("@book_img_link", book1.BookImgLink);

                cmd.ExecuteNonQuery();
                con.Close();
               

            }
            catch (Exception ex)
            {
                
            }



        }

        public void updateBook(Book book1)
        {
            try
            {              

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + book1.BookID+ "'", con);

                
                cmd.Parameters.AddWithValue("@book_name", book1.BookName);
                cmd.Parameters.AddWithValue("@genre", book1.Genre);
                cmd.Parameters.AddWithValue("@author_name", book1.AuthorName);
                cmd.Parameters.AddWithValue("@publisher_name", book1.PublisherName);
                cmd.Parameters.AddWithValue("@publish_date", book1.PublishDate);
                cmd.Parameters.AddWithValue("@language", book1.Language);
                cmd.Parameters.AddWithValue("@edition", book1.Edition);
                cmd.Parameters.AddWithValue("@book_cost", book1.BookCost);
                cmd.Parameters.AddWithValue("@no_of_pages", book1.NoPages);
                cmd.Parameters.AddWithValue("@book_description", book1.BookDesc);
                cmd.Parameters.AddWithValue("@actual_stock", book1.ActualStock);
                cmd.Parameters.AddWithValue("@current_stock", book1.CurrStock);
                cmd.Parameters.AddWithValue("@book_img_link", book1.BookImgLink);


                cmd.ExecuteNonQuery();
                con.Close();
               


            }
            catch (Exception ex)
            {
                
            }
        }

        public void deleteBook(string bookID)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + bookID + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                

            }
            catch (Exception ex)
            {
               
            }
        }
    }
}