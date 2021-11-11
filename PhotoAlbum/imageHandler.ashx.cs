using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace PhotoAlbum
{
    /// <summary>
    /// Summary description for imageHandler
    /// </summary>
    public class imageHandler : IHttpHandler
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ghost\Documents\ImageGallery.mdf;Integrated Security=True;Connect Timeout=30";
        public SqlConnection con;
        public SqlCommand com;
        
        public void ProcessRequest(HttpContext context)
        {

            string imageID = context.Request.QueryString["imageID"];
            con = new SqlConnection(connectionString);
            string sql = "SELECT image from Images WHERE imageID=" + imageID;
            com = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            context.Response.BinaryWrite((Byte[])dr[0]);
            context.Response.ContentType = "image/jpg";
            context.Response.End();
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

       
    }
}