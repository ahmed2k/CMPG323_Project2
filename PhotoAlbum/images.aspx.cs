using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace PhotoAlbum
{
    public partial class images : System.Web.UI.Page
    {
        public SqlConnection con;
        public SqlCommand com;
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ghost\Documents\ImageGallery.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //    BindGrid();
        }

        private void saveImage()
        {
            if (FileUpload1.HasFile)
            {
                int imageFileLen = FileUpload1.PostedFile.ContentLength;
                byte[] imgarray = new byte[imageFileLen];
                HttpPostedFile image = FileUpload1.PostedFile;
                image.InputStream.Read(imgarray, 0, imageFileLen);
                con = new SqlConnection(connectionString);
                con.Open();
                string sql = "INSERT INTO Images(imageName,image) values(@imageName,@image)";
                com = new SqlCommand(sql,con);

                com.Parameters.AddWithValue("@imageName", TextBox1.Text);
                com.Parameters.AddWithValue("@image", imgarray);
                com.ExecuteNonQuery();
                con.Close();
              //  BindGrid();
                
            }
        }



        protected void btnUpload_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        public void BindGrid() {
            con = new SqlConnection(connectionString);
            string sql= "SELECT * from Images";
            com = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
        }
    }
}