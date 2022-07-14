using Microsoft.AspNetCore.Mvc;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class ProductController : Controller
    {
        private readonly shopContext _shopContext;
        public ProductController(shopContext db)
        {
            _shopContext=db;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult createProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createProduct(Product p)
        {
            if(p == null)
            {
                return NotFound();
                return RedirectToAction("createProduct");
            }
            else
            {
                _shopContext.Products.Add(p);
                _shopContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
