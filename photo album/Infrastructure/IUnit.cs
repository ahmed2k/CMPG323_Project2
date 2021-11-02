using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Infrastructure
{
    public interface IUnit
    {
        IAlbumRepo albumRepo { get; }
        IimagesRepo iimagesRepo { get; }
        void save();
        void uploadFile(List<IFormFile> files);
    }
}
