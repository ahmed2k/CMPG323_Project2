using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PhotoAlbum
{
    public partial class Albums : System.Web.UI.Page
    {
        public SqlConnection con;
        public SqlCommand com;
        public DataSet ds;
        SqlDataAdapter adap;
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ghost\Documents\ImageGallery.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            con.Close();
            Label1.Text = "success";
        }

        public void delete()
        {
            con = new SqlConnection(connectionString);
            string insertValue = TextBox1.Text;
            con.Open();
            ds = new DataSet();
            adap = new SqlDataAdapter();
            string sql = "INSERT INTO Albums VALUES('" + insertValue + "')";
            com = new SqlCommand(sql, con);
            ds = new DataSet();
            adap.SelectCommand = com;
            adap.Fill(ds);
            con.Close();
            Response.Redirect("Albums.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            string insertValue = TextBox1.Text;
            con.Open();
            ds = new DataSet();
            adap = new SqlDataAdapter();
            string sql = "INSERT INTO Albums VALUES('" + insertValue + "')";
            com = new SqlCommand(sql, con);
            ds = new DataSet();
            adap.SelectCommand = com;
            adap.Fill(ds);
            con.Close();
            Response.Redirect("Albums.aspx");
        }

        public  void selectMethod() {
            Label1.Text = "This method was invoked";
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            con = new SqlConnection(connectionString);
            con.Open();
            string sqlStatement = "SELECT * FROM Albums";
            com = new SqlCommand(sqlStatement, con);
            ds = new DataSet();
            adap = new SqlDataAdapter();
            adap.SelectCommand = com;
            adap.Fill(ds);
            GridView1.DataSource = ds;
           // albumGrid.DataBind();
            con.Close();

        }
    }
}