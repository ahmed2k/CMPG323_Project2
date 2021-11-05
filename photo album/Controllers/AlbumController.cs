using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using photo_album.Infrastructure;
using photo_album.Models;
using photo_album.ViewModels.albumsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IUnit _unit;
        private readonly IMapper _mapper;

        public AlbumController(IUnit _unit, IMapper _mapper)
        {
            this._unit = _unit;
            this._mapper = _mapper;
        }

        //GET ALBUM
        public ActionResult Index()
        {
            var albums = _unit.albumRepo.GetAll();
            var mappedAlbums = _mapper.Map<List<albumsViewModel>>(albums);
            return View(mappedAlbums);

        }

        //GET album details
        public ActionResult Details(int Id)
        {
            var albums = _unit.albumRepo.getById(Id);
            var mappedAlbums = _mapper.Map<albumsViewModel>(albums);
            return View(mappedAlbums);
        }

        //GET: Album-create new
        public ActionResult Create()
        {
            return View();
        }

        //POST: Album-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(createAlbumViewModel album)
        {
            try
            {
                var mappedAlbum = _mapper.Map<Album>(album);
                _unit.albumRepo.insert(mappedAlbum);
                _unit.save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: Category/Edit


        public ActionResult Edit(int id)
        {
            var albums = _unit.albumRepo.getById(id);
            var mappedAlbums = _mapper.Map<editAlbumViewModel>(albums);
            return View(mappedAlbums);
        }

        //POST: album/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(editAlbumViewModel vm)
        {
            try
            {
                var album = _mapper.Map<Album>(vm);
                _unit.albumRepo.insert(album);
                _unit.save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: Album-delete
        public ActionResult Delete(int id)
        {
            var albums = _unit.albumRepo.getById(id);
            var mappedAlbums = _mapper.Map<albumsViewModel>(albums);
            return View(mappedAlbums);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int Id,albumsViewModel album)
        {
            try
            {
                _unit.albumRepo.delete(Id);
                _unit.save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
