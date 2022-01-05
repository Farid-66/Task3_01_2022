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
    public class HeaderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HeaderController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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

            if (model.ImageFile != null)
            {
                string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Profile);
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

                model.Profile = fileName;


            }
            _context.Mains.Update(model);
            _context.SaveChanges();

            return Redirect("../Home/Index");
        }
    }
}
