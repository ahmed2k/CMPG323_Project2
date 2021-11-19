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
    public partial class images : System.Web.UI.Page
    {
        public SqlConnection con;
        public SqlCommand com;
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ghost\Documents\ImageGallery.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
           
          
        }

        public void BindGrid() {
            GridView1.DataSource = null;
            GridView1.DataSourceID = null;
            con = new SqlConnection(connectionString);
            string sql= "SELECT * from Images WHERE [User] = '"+Session["User"].ToString()+"' ";
            com = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            Response.Write("Welcome" + Session["User"].ToString());
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            string sql = "SELECT * from Images WHERE [User] = '" + Session["User"].ToString() + "' ";
            com = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            Response.Write("<script>alert('" + Session["User"] + "')");
            GridView1.DataSource = SqlDataSource1;

        }

        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int inId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        //    con = new SqlConnection(connectionString);
        //    con.Open();
        //    SqlCommand c = new SqlCommand("DELETE FROM Images WHERE ImageID = '" + inId + "'", con);
        //    c.Parameters.AddWithValue("@ImageID", inId);
        //    c.ExecuteNonQuery();
        //    GridView1.DataBind();
        //    con.Close();
        //}

        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex;
        //    BindGrid();

        //}

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    BindGrid();
        //}

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //con = new SqlConnection(connectionString);
            //con.Open();
            //int rowIndex = e.RowIndex;
            //GridViewRow row = GridView1.Rows[rowIndex];

            //int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            //string imageName = (row.FindControl("[ImagesName]") as TextBox).Text;
            //string captureBy = (row.FindControl("[capturedBy]") as TextBox).Text;
            //string tags = (row.FindControl("[tags]") as TextBox).Text;
            //string location = (row.FindControl("[Location]") as TextBox).Text;

            //  SqlCommand cmd = new SqlCommand("update Images set ImagesName = '"+imageName+ "',capturedBy ='" + captureBy + "'," +
            // "tags = '" + tags + "',Location = '" + location+ "' where ImageID = '" +id + "'", con);

            //  cmd.ExecuteNonQuery();
            //
            // GridView1.EditIndex = -1;
            // con.Close();
           // Label1.Text = imageName + captureBy + tags + location;
          //  BindGrid();
            
        }

        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(GridView1.SelectedIndex);
            String name = GridView1.SelectedRow.Cells[2].Text;
            String capturedBy = GridView1.SelectedRow.Cells[4].Text;
            String Location = GridView1.SelectedRow.Cells[5].Text;
            String tags = GridView1.SelectedRow.Cells[6].Text;
            String User = GridView1.SelectedRow.Cells[7].Text;
            //Response.Write("<script>alert('" + name +capturedBy+Location+tags+User + "')</script>");
            //  Response.Write("<script>alert('" + i + "')</script>");
            con = new SqlConnection(connectionString);
            con.Open();
            string sql = "INSERT INTO Shared VALUES('" + name + "','" + capturedBy + "','" + Location + "','" + tags + "','" + User + "')";
            com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Image shared successfully')</script>");


        }
    }
}