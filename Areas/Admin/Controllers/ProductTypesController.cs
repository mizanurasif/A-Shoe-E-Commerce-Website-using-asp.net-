using Cobbler.Data;
using Cobbler.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cobbler.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
       public ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
           // var data = _db.ProductTypes.ToList();

            return View(_db.ProductTypes.ToList());
        }
        //create Get Action Method

        public ActionResult Create()
        {

            return View();
        }

        //Create post Action Method
         [HttpPost]
         [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if(ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product type has been saved";
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }
       // get Edit action method
        public ActionResult Edit( int ? id)
        {
            if(id==null)
            {
                return NotFound();

            }
            var productType = _db.ProductTypes.Find(id);
            if(productType==null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // post Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Update(productTypes);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Product type has been updated";
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }



        // get Details action method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // post  Details Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult  Details(ProductTypes productTypes)
        {
          
                return RedirectToAction(nameof(Index));
            
        }
        // get Delete action method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        // post Delete Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete( int id,ProductTypes productTypes)
        {
            if(id==null)
            {
                return NotFound();
            }
            if(id!=productTypes.Id)
            {
                return NotFound();

            }
            var productType=_db.ProductTypes.Find(id); 
            if(productType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Product type has been updated";
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }
    }
}
