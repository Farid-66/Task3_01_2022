using FullSite.Data;
using FullSite.Models;
using FullSite.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FullSite.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmHome model = new VmHome();
            model.Main = _context.Mains.FirstOrDefault();
            model.Portfolio = _context.Portfolios.ToList();

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        

    }
}
