using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.DAL;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class SellersController : Controller
    {
       
        private readonly ISellerRepo _sellerRepo;
        public SellersController(shopContext context)
        {
            _sellerRepo=new SellerRepo(new shopContext());
        }

        // GET: Sellers
        public async Task<IActionResult> Index()
        {
            return View(await _sellerRepo.GetSellerList());
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller =await _sellerRepo.GetSellerById(id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Seller_id,Seller_name,Password,age,phoneNumber")] Seller seller)
        {


            await _sellerRepo.AddSeller(seller);
            await _sellerRepo.Save();
               
            return View(seller);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _sellerRepo.GetSellerById(id);
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Seller_id,Seller_name,Password,age,phoneNumber")] Seller seller)
        {
            if (id != seller.Seller_id)
            {
                return NotFound();
            }

            
                    await _sellerRepo.UpdateSeller(seller);
                    await _sellerRepo.Save();
              
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _sellerRepo.GetSellerById(id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            
            await _sellerRepo.DeleteSeller(id);
            await _sellerRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
