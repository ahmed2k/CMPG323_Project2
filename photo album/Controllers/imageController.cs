using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using photo_album.Infrastructure;
using photo_album.ViewModels.imageViewModel;
using System;
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

    }
}
