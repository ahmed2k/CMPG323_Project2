using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.ViewModels.imageViewModel
{
    public class imageEditViewModel
    {
        public int Id { get; set; }
        public string imagePath { get; set; }

        public IFormFile File { get; set; }

        public int AlbumId { get; set; }

    }
}
