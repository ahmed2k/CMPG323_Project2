using Microsoft.EntityFrameworkCore;
using photo_album.Data;
using photo_album.Infrastructure;
using photo_album.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Services
{
    public class imagesRepo : IimagesRepo
    {
        private readonly Context _context;

        public imagesRepo(Context context)
        {
            _context = context;
        }

        public void addRange(List<images> model)
        {
            _context.images.AddRange(model);
        }

        public void delete(int id)
        {
            var mediaManager = getById(id);
            _context.images.Remove(mediaManager);

        }

        public List<images> GetAll()
        {
            var data = _context.images.Include(x => x.album).ToList();
            return data;
        }

        public images getById(int id)
        {
            return _context.images.Where(x => x.Id == id).Include(x => x.album).FirstOrDefault();
        }

        public void insert(images imageManager)
        {
            _context.images.Add(imageManager);
        }

        public void update(images imageManager)
        {
            _context.images.Update(imageManager);
        }
    }
}
