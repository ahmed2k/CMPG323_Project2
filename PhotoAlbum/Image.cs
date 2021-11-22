using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum
{
    public class Image
    {
        public int imageId;
        public string imageName;
        public string capturedBy;

        public Image(int imageId, string imageName,string capturedBy)
        {
            this.imageId = imageId;
            this.imageName = imageName;
            this.capturedBy = capturedBy;
        }

        public string getImageName()
        {
            return imageName;
        }
        public void setAlbumName(string imageName)
        {
            this.imageName = imageName;

        }
        public int getImageId()
        {
            return imageId;
        }

        public void setImageId(int imageId)
        {
            this.imageId = imageId;

        }
        
        public void setCapturedBy(string capturedBy)
        {
            this.capturedBy = capturedBy;
        }

        public string getCapturedBy()
        {
            return capturedBy;
        }



    }
}