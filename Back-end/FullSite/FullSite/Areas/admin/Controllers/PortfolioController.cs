using FullSite.Data;
using FullSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace FullSite.Areas.admin.Controllers
{
    [Area("admin")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PortfolioController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Portfolio model)
        {
            string fileName = Guid.NewGuid() + "" + model.ImageFile.FileName;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.ImageFile.CopyTo(stream);
            }

            model.Image = fileName;
            model.CreateDate = DateTime.Now;
            _context.Portfolios.Add(model);
            _context.SaveChanges();

            return Redirect("../Home/Index");
        }

        public IActionResult Update(int? id)
        {
            return View(_context.Portfolios.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Portfolio model)
        {

            if (model.ImageFile != null)
            {
                string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                string fileName = Guid.NewGuid() + "" + model.ImageFile.FileName;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                model.Image = fileName;


            }
            _context.Portfolios.Update(model);
            _context.SaveChanges();

            return Redirect("../Home/Index");
        }

        public IActionResult Delete(int? id)
        {
            Portfolio portfolio = _context.Portfolios.Find(id);

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", portfolio.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.Portfolios.Remove(portfolio);
            _context.SaveChanges();

            return Redirect("../Home/Index");
        }
    }
}
