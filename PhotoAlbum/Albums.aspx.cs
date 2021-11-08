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
            string sqlStatement = "SELECT * FROM Albums";
            con.Open();
            com = new SqlCommand(sqlStatement,con);
            ds = new DataSet();
            adap = new SqlDataAdapter();
            adap.SelectCommand = com;
            adap.Fill(ds);
            albumGrid.DataSource = ds;
            albumGrid.DataBind();
            con.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            con.Close();
            Label1.Text = "success";
        }
    }
}