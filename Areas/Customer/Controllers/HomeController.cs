using Cobbler.Data;
using Cobbler.Models;
using Cobbler.Utiliy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cobbler.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
             return View(_db.Products.Include(c => c.ProductTypes).ToList());
        }
        public IActionResult Man()
        {
            return View(_db.Products.Include(c => c.ProductTypes).ToList());
        }
        public IActionResult Woman()
        {
            return View(_db.Products.Include(c => c.ProductTypes).ToList());
        }
        public IActionResult Accessories()
        {
            return View(_db.Products.Include(c => c.ProductTypes).ToList());
        }
        public IActionResult Detail(int ? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var products = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c=>c.Id==id);
            if(products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost]
        [ActionName("Detail")]
        public ActionResult ProductDetail(int? id)
        {
            List<Products> products = new List<Products>();
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            products = HttpContext.Session.Get<List<Products>>("products");
            if (products == null)
            {
                products = new List<Products>();
            }
            products.Add(product);
            HttpContext.Session.Set("products", products);
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public IActionResult Remove(int? id)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cart()
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products == null)
            {
                products = new List<Products>();
            }
            return View(products);

        }

        [ActionName("Remove")]
        public IActionResult RemovefromCart(int? id)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Cart));
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
