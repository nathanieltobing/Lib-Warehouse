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
using Lib_Warehouses.Repository;


namespace Lib_Warehouses.View
{
    public partial class bookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        BookFactory bFactory = new BookFactory();
        BookRepository bRepo = new BookRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            GridView1.DataBind();
        }

        //go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text.Trim();
            string username = TextBox2.Text.Trim();
            if (bRepo.checkIfBookExist(id,username))
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else
            {
                addNewBook();
            }
        }
    

        protected void Button3_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }

        void deleteBookByID()
        {
            string id = TextBox1.Text.Trim();
            string username = TextBox2.Text.Trim();
            if (bRepo.checkIfBookExist(id,username))
            {
                try
                {
                    bRepo.deleteBook(id);
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        void updateBookByID()
        {
            string id = TextBox1.Text.Trim();
            string username = TextBox2.Text.Trim();
                
            if (bRepo.checkIfBookExist(id,username))
            {
                try
                {

                    int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox5.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox5.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + TextBox1.Text.Trim() + "'", con);

                    string bookID = TextBox1.Text.Trim();
                    string bookName = TextBox2.Text.Trim();
                    string genre = genres;
                    string authorName = TextBox8.Text.Trim();
                    string publisherName = TextBox12.Text.Trim();
                    string publishDate = TextBox3.Text.Trim();
                    string language = DropDownList1.SelectedItem.Value;
                    string edition = TextBox9.Text.Trim();
                    string bookCost = TextBox10.Text.Trim();
                    string noPages = TextBox11.Text.Trim();
                    string bookDesc = TextBox6.Text.Trim();
                    string actualStock = actual_stock.ToString();
                    string currStock = current_stock.ToString();
                    string bookImgLink = filepath;

                    Book book1 = bFactory.getBook(bookID, bookName, genre, authorName,
                        publisherName, publishDate, language, edition, bookCost, noPages,
                        bookDesc, actualStock, currStock, bookImgLink);

                    bRepo.updateBook(book1);


                   
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }

        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["edition"].ToString();
                    TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["book_description"].ToString();
                    TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    TextBox12.Text = dt.Rows[0]["publisher_name"].ToString();
                    TextBox8.Text = dt.Rows[0]["author_name"].ToString();

                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }

        void addNewBook()
        {
            
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("/book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                string bookID = TextBox1.Text.Trim();
                string bookName = TextBox2.Text.Trim();
                string genre = genres;
                //string genre = "asasa";
                string authorName = TextBox8.Text.Trim();
                string publisherName = TextBox12.Text.Trim();
                string publishDate = TextBox3.Text.Trim();
                string language = DropDownList1.SelectedItem.Value;
                string edition = TextBox9.Text.Trim();
                string bookCost = TextBox10.Text.Trim();
                string noPages = TextBox11.Text.Trim();
                string bookDesc = TextBox6.Text.Trim();
                string actualStock = TextBox4.Text.Trim();
                string currStock = TextBox4.Text.Trim();
                string bookImgLink = filepath;
                //string bookImgLink = "asasa";

                Book book1 = bFactory.getBook(bookID, bookName, genre, authorName,
                    publisherName, publishDate, language, edition, bookCost, noPages,
                    bookDesc, actualStock, currStock, bookImgLink);

                bRepo.insertBook(book1);
               
                Response.Write("<script>alert('Book added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                Response.Write("<script>alert('Book Failed successfully.');</script>");
            }
        }

        
    }
    
}