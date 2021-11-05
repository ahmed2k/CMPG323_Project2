using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using photo_album.Data;
using photo_album.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Services
{
    public class Unit : IUnit
    {
        private readonly Context _context;
        private IAlbumRepo _albumRepo;
        private IimagesRepo _iimagesRepo;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public Unit(Context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IAlbumRepo albumRepo
        {
            get
            {
                return _albumRepo = _albumRepo ?? new AlbumRepo(_context);
            }
        }

        public IimagesRepo iimagesRepo
        {
            get
            {
                return _iimagesRepo = _iimagesRepo ?? new imagesRepo(_context);
            }
        }

        public void save()
        {
            _context.SaveChanges();
        }

        [Obsolete]
        public async void uploadFile(List<IFormFile> files)
        {
            foreach (IFormFile item in files)
            {
                long toatalBytes = files.Sum(f => f.Length);
                string fileName = item.FileName.Trim('"');
                fileName = EnsureFileName(fileName);
                byte[] buffer = new byte[16 * 1024];
                using (FileStream output = File.Create(GetpathAndFileName(fileName)))
                {
                    using (Stream input = item.OpenReadStream())
                    {
                        int readBytes;
                        while((readBytes = input.Read(buffer, 0,buffer.Length)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, readBytes);
                            toatalBytes += toatalBytes;
                        }
                    }
                }
            }
        }

        private string EnsureFileName(string fileName)
        {
            if (fileName.Contains("\\"))
            {
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            }
            return fileName;
        }

        [Obsolete]
        private string GetpathAndFileName(string fileName)
        {
            string path = hostingEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + fileName;
        }
    }
}
