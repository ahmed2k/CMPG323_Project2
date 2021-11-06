using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using photo_album.Infrastructure;
using photo_album.Models;
using photo_album.ViewModels.imageViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Controllers
{
    public class imageController : Controller
    {
        //GET: image manager
        private readonly IUnit _unit;
        private readonly IMapper _mapper;

        public imageController(IUnit _unit, IMapper _mapper)
        {
            this._unit = _unit;
            this._mapper = _mapper;

        }

        public ActionResult Index()
        {
            var image = _unit.iimagesRepo.GetAll();
            var mappedImages = _mapper.Map<List<imageViewModel>>(image);
            return View(mappedImages);
        }

        //GET images details
        public ActionResult Details(int Id)
        {
            var images = _unit.albumRepo.getById(Id);
            var mappedImages = _mapper.Map<imageViewModel>(images);
            return View(mappedImages);
        }

        //GET: image manager
        public ActionResult Create()
        {
            ViewBag.album = _unit.albumRepo.GetAll();
            return View();

        }

        //POST: media creater
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(imageCreateViewModel vm)
        {
            try
            {
                var album = _unit.albumRepo.getById(vm.AlbumId);
                List<images> image = new List<images>();
                foreach (var file in vm.Files)
                {
                    image.Add(new images()
                    {
                        imageUrl = file.FileName,
                        album = album
                    }); 
                }
                

                _unit.uploadFile(vm.Files);
                _unit.iimagesRepo.addRange(image);
                _unit.save();

                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        //GET : EDIT
        public ActionResult Edit(int id)
        {
            ViewBag.albums = _unit.albumRepo.GetAll();
            var image = _unit.iimagesRepo.getById(id);
            var mappedImages = _mapper.Map<imageEditViewModel>(image);
            return View(mappedImages);
        }

        //POST : edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(imageEditViewModel vm)
        {
            try
            {
                if(vm.File ==null && _unit.iimagesRepo.getById(vm.Id).AlbumId == vm.AlbumId)
                {
                    RedirectToAction(nameof(Index));
                }
                else if(vm.File != null)
                {
                    List<IFormFile> files = new List<IFormFile>();
                    files.Add(vm.File);

                    var updateImage = _unit.iimagesRepo.getById(vm.Id);
                    updateImage.AlbumId = vm.AlbumId;
                    updateImage.imageUrl = vm.File.FileName;

                    _unit.uploadFile(files);
                    _unit.iimagesRepo.update(updateImage);
                    _unit.save();
                    RedirectToAction(nameof(Index));
                }
                else if(_unit.iimagesRepo.getById(vm.Id).AlbumId != vm.AlbumId)
                {
                    List<IFormFile> files = new List<IFormFile>();
                    files.Add(vm.File);
                    var updateImage = _unit.iimagesRepo.getById(vm.Id);
                    updateImage.AlbumId = vm.AlbumId;
                    updateImage.imageUrl = _unit.iimagesRepo.getById(vm.Id).imageUrl;

                    //unit of work upload files
                    _unit.iimagesRepo.update(updateImage);
                    _unit.save();
                    RedirectToAction(nameof(Index));

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //POST: Delete

        public ActionResult Delete(int id) { 
            var model = _unit.iimagesRepo.getById(id);
            var vm = _mapper.Map<imageViewModel>(model);

            return View(vm);
        }

        //POST: delete

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, IFormFile collection)
        {
            try
            {
                _unit.iimagesRepo.delete(id);
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
