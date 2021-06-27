using AspMagaz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MagazContext _context;

        [Route("Category/{id:int}")]
        public IActionResult Index(int id)
        {
            var prod = _context.Products.Where(x => x.Id == id)
                                        .Include(x => x.Category)
                                        .First();
            ViewBag.Images = GetImages(id);
            return View(prod);
        }

        public IActionResult Search(string searched)
        {
            return View("Products", _context.Products.Where(x => x.Name.Contains(searched)));
        }

        public IActionResult Smartphones()
        {
            return View("Products", _context.SmartphoneProducts);
        }

        public IActionResult GetImage(int Id)
        {
            return File(_context.Photoes.First(x => x.Id == Id).Image, "image/jpeg");
        }
        public IActionResult GetPrimaryImage(int Id)
        {
            var filelocation = _context.Photoes.FirstOrDefault(x => x.Product.Id == Id && x.IsPrimary == true)?.Image;
            if(filelocation is not null)
                return File(filelocation, "image/jpeg");
            return Content("");
        }
        private int[] GetImages(int Id)
        {
            return _context.Photoes.Where(x => x.Product.Id == Id).OrderByDescending(x => x.IsPrimary).Select(x => x.Id).ToArray();
        }

        public IActionResult Laptops()
        {
            return View("Products", _context.LaptopProducts);
        }

        public CategoryController(MagazContext context)
        {
            _context = context;
        }
    }
}
