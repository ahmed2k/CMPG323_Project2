using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace PhotoAlbum
{
    public partial class display : System.Web.UI.Page
    {
        public SqlConnection con;
        public SqlCommand com;
        public DataSet ds;
        public SqlDataAdapter adap;
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ghost\Documents\ImageGallery.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            com = new SqlCommand("SELECT * FROM Images", con);
            ds = new DataSet();
            adap = new SqlDataAdapter();
            adap.SelectCommand = com;
            adap.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            // Response.Redirect("images.aspx");
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            string search_value = TextBox1.Text;
            string sql = "SELECT ImagesName,tags,Location,User FROM Shared WHERE ImagesName LIKE '%" + search_value + "%'" +
                "OR  Location LIKE '%" + search_value + "%' OR tags LIKE '%" + search_value + "%'";
            ds = new DataSet();
            adap = new SqlDataAdapter();
            com = new SqlCommand(sql, con);
            adap.SelectCommand = com;
            adap.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            // Response.Redirect("images.aspx");
            con.Close();
        }
    }
}