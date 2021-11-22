using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum
{
    public class Album
    {
        public int albumId;
        public string albumName;

        public Album(int albumId,string albumName)
        {
            this.albumId = albumId;
            this.albumName = albumName;
        }

        public string getAlbumName()
        {
            return albumName;
        }

        public int getAlbumId()
        {
            return albumId;
        }

        public void setAlbumId(int albumId)
        {
            this.albumId = albumId;

        }

        public void setAlbumName(string albumName)
        {
            this.albumName = albumName;

        }
    }
}