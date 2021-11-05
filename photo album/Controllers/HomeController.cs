using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using photo_album.Infrastructure;
using photo_album.Models;
using photo_album.ViewModels.imageViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnit _unit;
        private IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnit _unit, IMapper _mapper)
        {
            this._unit = _unit;
            this._mapper = _mapper;
        }

        public IActionResult Index()
        {
            var model = _unit.iimagesRepo.GetAll();
            var vm = _mapper.Map<List<imageViewModel>>(model);
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
