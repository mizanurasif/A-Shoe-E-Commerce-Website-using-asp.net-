using Cobbler.Data;
using Cobbler.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cobbler.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        [System.Obsolete]
        private IHostingEnvironment _he;

        [System.Obsolete]
        public ProductController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }


        public IActionResult Index()
        {
            return View(_db.Products.Include(c => c.ProductTypes).ToList());
        }

        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            var products = _db.Products.Include(c => c.ProductTypes)
                .Where(c => c.Price >= lowAmount && c.Price <= largeAmount).ToList();
            if (lowAmount == null || largeAmount == null)
            {
                products = _db.Products.Include(c => c.ProductTypes).ToList();
            }
            return View(products);
        }


        //Get create method
        public IActionResult Create()
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
            return View();

        }

        //post create method

        [HttpPost]
        [System.Obsolete]
        public async Task<IActionResult> Create(Products products, IFormFile image1, IFormFile image2, IFormFile image3, IFormFile image4)
        {
            if (image1 != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image1.FileName));
                await image1.CopyToAsync(new FileStream(name, FileMode.Create));
                products.Image_Main = "Images/" + image1.FileName;
            }
            if (image2 != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image2.FileName));
                await image2.CopyToAsync(new FileStream(name, FileMode.Create));
                products.Image_secondary = "Images/" + image2.FileName;
            }
            if (image3 != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image3.FileName));
                await image3.CopyToAsync(new FileStream(name, FileMode.Create));
                products.Image_extra1 = "Images/" + image3.FileName;
            }
            if (image4 != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image4.FileName));
                await image4.CopyToAsync(new FileStream(name, FileMode.Create));
                products.Image_extra2 = "Images/" + image4.FileName;
            }
            if (image1 == null)
            {
                products.Image_Main = "Images/noimage.PNG";
            }
            if (image2 == null)
            {
                products.Image_secondary = "Images/noimage.PNG";
            }
            if (image3 == null)
            {
                products.Image_extra1 = "Images/noimage.PNG";
            }
            if (image4 == null)
            {
                products.Image_extra2 = "Images/noimage.PNG";
            }

            if (ModelState.IsValid)
            {
                _db.Products.Add(products);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
            return View(products);
        }

        //Get Edit method
        public ActionResult Edit(int? id)
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //post Edit method

        [HttpPost]
        [System.Obsolete]
        public async Task<IActionResult> Edit(Products products, IFormFile image1, IFormFile image2, IFormFile image3, IFormFile image4)
        {
            if (image1 != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image1.FileName));
                await image1.CopyToAsync(new FileStream(name, FileMode.Create));
                products.Image_Main = "Images/" + image1.FileName;
            }
            if (image2 != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image2.FileName));
                await image2.CopyToAsync(new FileStream(name, FileMode.Create));
                products.Image_secondary = "Images/" + image2.FileName;
            }
            if (image3 != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image3.FileName));
                await image3.CopyToAsync(new FileStream(name, FileMode.Create));
                products.Image_extra1 = "Images/" + image3.FileName;
            }
            if (image4 != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image4.FileName));
                await image4.CopyToAsync(new FileStream(name, FileMode.Create));
                products.Image_extra2 = "Images/" + image4.FileName;
            }
            if (image1 == null)
            {
                products.Image_Main = "Images/noimage.PNG";
            }
            if (image2 == null)
            {
                products.Image_secondary = "Images/noimage.PNG";
            }
            if (image3 == null)
            {
                products.Image_extra1 = "Images/noimage.PNG";
            }
            if (image4 == null)
            {
                products.Image_extra2 = "Images/noimage.PNG";
            }

            if (ModelState.IsValid)
            {
                _db.Products.Update(products);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
             
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
            return View(products);
        }
        //GET Details Action Method
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.ProductTypes).Where(c => c.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //POST Delete Action Method

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}
