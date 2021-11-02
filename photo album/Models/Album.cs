using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Media;

namespace photo_album.Models
{
    public class Album
    {
        public int id { get; set; }
        public String Name { get; set; }

        public List<images> Media { get; set; } = new List<images>();

    }
}
