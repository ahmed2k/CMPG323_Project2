using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Models
{
    public class images
    {
        public int Id { get; set; }
        public string imageUrl { get; set; }
        public int AlbumId { get; set; }
        public Album album { get; set; } = new Album();

    }
}
