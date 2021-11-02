using photo_album.Data;
using photo_album.Infrastructure;
using photo_album.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Services
{
    public class AlbumRepo : IAlbumRepo
    {
        private readonly Context _context;

        public AlbumRepo(Context context)
        {
            _context = context
        }

        public void delete(int id)
        {
            var album = getById(id);
            _context.albums.Remove(album);
        }

        public List<Album> GetAll()
        {
            return _context.albums.ToList();
        }

        public Album getById(int id)
        {
            return _context.albums.Where(x => x.id == id).FirstOrDefault();
        }

        public void insert(Album album)
        {
            _context.albums.Add(album);
        }

        public void update(Album album)
        {
            _context.albums.Update(album);
        }
    }
}
