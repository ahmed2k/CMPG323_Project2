using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.ViewModels.imageViewModel
{
    public class imageCreateViewModel
    {
        public List<IFormFile> Files { get; set; }
        public int AlbumId { get; set; }
    }
}
