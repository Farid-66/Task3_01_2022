using FullSite.Data;
using FullSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FullSite.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {

        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View(_context.Mains.FirstOrDefault());
        }


        [HttpPost]
        public IActionResult Update(Main model)
        {
            _context.Mains.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
