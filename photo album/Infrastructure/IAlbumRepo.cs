using photo_album.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Infrastructure
{
    public interface IAlbumRepo
    {
        List<Album> GetAll();
        Album getById(int id);
        void insert(Album album);
        void update(Album album);
        void delete(int id);
    }
}
