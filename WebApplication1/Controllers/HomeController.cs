using biznis.Interfaces.Services;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController(ILogger<HomeController> logger, AppDbContext context, IUserService userService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly AppDbContext db = context;
        private readonly IUserService _userService = userService;

        public IActionResult Index()
        {
            return View();
        }


       public IActionResult Products()
        {
            var products = db.Products.ToList();
            return View(products);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
