using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB.ViewModels;
using PB.Data;
using PB.Models;
using SQLitePCL;
using System.Diagnostics;

namespace PB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Artistas = _context.Artistas.ToList(),
                Eventos = _context.Eventos.ToList()
            };

            return View(viewModel);
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

        public IActionResult Search(string query)
        {
            var viewModel = new HomeViewModel
            {
                Artistas = _context.Artistas
                    .Where(a => a.Nome.Contains(query))
                    .ToList(),
                Eventos = _context.Eventos
                    .Where(e => e.Nome.Contains(query))
                    .ToList()
            };

            return View("Index", viewModel);
        }



    }
}
