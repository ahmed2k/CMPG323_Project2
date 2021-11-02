using photo_album.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Infrastructure
{
   public interface IimagesRepo
    {
        List<images> GetAll();
        images getById(int id);
        void insert(images imageManager);
        void update(images imageManager);
        void delete(int id);

        void addRange(List<images> model);

    }
}
