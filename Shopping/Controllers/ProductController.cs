using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.Models;
using Shopping.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Shopping.DAL;
using System.Collections.Generic;

namespace Shopping.Controllers
{
    public class ProductController : Controller
    {
        
        public IProductRepo _productRepo { get; set; }
        private ISellerRepo _sellerRepo { get; set; }
        private IProductMapRepo _productMapRepo { get; set; } 
        private IWebHostEnvironment _env;
        public ProductController( IWebHostEnvironment env)
        {
            _productRepo = new ProductRepo(new shopContext());
            _sellerRepo = new SellerRepo(new shopContext());
            _productMapRepo = new ProductMapRepo(new shopContext());
            _env = env;
        }
        
       
       
        
        
       
        public IActionResult ProductHome()
        {
            return View();
        }

        #region product crud operations
        public async Task<IActionResult> Index()
        {
            
            return View(await _productRepo.GetProductList());
        }
        // GET: Product/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _productRepo.GetProductById(id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        public async Task<IActionResult> createProduct()
        {
            //drop down for seller id in product table. 

            var result = new SelectList(from i in await _sellerRepo.GetSellerList() select i.Seller_id).ToList();
            ViewBag.Seller_id = result;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> createProduct(Product p)
        {
            
            if (p.Pimage != null)
            {
                var uploads = Path.Combine(_env.WebRootPath, "Uploads");
                var filePath = Path.Combine(uploads, p.Pimage.FileName);

                p.Pimage.CopyTo(new FileStream(filePath, FileMode.Create));
                p.ImageName = p.Pimage.FileName; 
            }


            await _productRepo.InsertProduct(p);
            await _productRepo.Save();
         
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            await _productRepo.DeleteProduct(id);
            await _productRepo.Save();
            return RedirectToAction(nameof(Index));
        }
#endregion

        public IActionResult AllProductLocation()
        {
            return View(_productMapRepo.GetProductMapList());
        }
        public async Task<IActionResult> AddProductLocation()
        {
            var result = new SelectList(from i in await _productRepo.GetProductList() select i.Product_id).ToList();
            ViewBag.Product_Id = result;
            return View();
        }
        [HttpPost]
        public IActionResult AddProductLocation(ProductMap pm)
        {
            _productMapRepo.InsertProductMap(pm);
            _productMapRepo.Save();
            return RedirectToAction("AllProductLocation");
        }
        public IActionResult ProductLocationDetails(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var product = _productMapRepo.GetProductMapList()
                .FirstOrDefault(m => m.TrackId == id);
            if (product == null)
            {
                return NotFound();
            }

            string location = product.PLocation;
             
            string[] locat = location.Split(", ");
            ViewBag.Location = locat;

            return View(product);
        }
        public IActionResult SearchProduct()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> SearchResult(string SearchPhrase)
        {
            var a = await _productRepo.GetProductList();
            
            return View(a.Where(i => i.Product_name.Contains(SearchPhrase)).ToList());
        }
        
        // Note....
        public IActionResult Direction(string id)
        {

            StringBuilder t = new StringBuilder();
            foreach (var i in _productMapRepo.GetProductMapList())
            {

                if (id != i.Product_id)
                {

                    continue;
                }
                else
                {
                    t.Append(i.TrackId);
                    break;
                }
            }

            ProductMap productMap = _productMapRepo.GetProductMapById(t.ToString());
            string s = productMap.PLocation;
            List<string> list = new List<string>();
            list = s.Split(',').ToList();
            ViewData["List"] = list;
            
            
            return View(productMap);
            
        }
        #region Seller
        public async Task<IActionResult> SellerByProductId(string id)
        {

            StringBuilder t = new StringBuilder();
            foreach (var i in await _productRepo.GetProductList())
            {

                if (id != i.Product_id)
                {

                    continue;
                }
                else
                {
                    t.Append(i.Seller_id);
                    break;
                }
            }

            Seller sellers =await _sellerRepo.GetSellerById(t.ToString()); 
            return View(sellers);
        }
        #endregion:ByProduct
        public async Task<IActionResult> SortByCategory()
        {
            var result = new SelectList(from i in await _productRepo.GetProductList() select i.type).ToList();
            ViewBag.type = result;
            return View();
        }
        
        public async Task<IActionResult> SortByCategory(string id)
        {
            var a=await _productRepo.GetProductList();
            return View("Index",a.Where(i => i.type.Contains(id)).ToList());
        }
        public async Task<IActionResult> SellerOtherProducts(string id)
        {
            var a = await _productRepo.GetProductList();
            return View("Index",a.Where(i => i.Seller_id==id).ToList());   
        }

    }
}
