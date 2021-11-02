using Microsoft.EntityFrameworkCore;
using photo_album.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Album> albums { get; set; }
        public DbSet<images> images { get; set; }
    }
    
}
