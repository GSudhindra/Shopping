using Microsoft.AspNetCore.Mvc;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly shopContext _shopContext;
        public PurchaseController(shopContext db)
        {
            _shopContext = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OffersForSenior(int id)
        {
           //Customer cust = _shopContext.Customers.Find(id);
            int age = id;
            if (age <= 40)
            {
                ViewBag.Offer = "Hey, Sorry. You didn't get the Offer";
            }
            else if(age>40 && age <= 50)
            {
                ViewBag.Offer = 10;
            }
            else if(age>50 && age<60)
            {
                ViewBag.Offer = 20;
            }
            else
            {
                ViewBag.Offer = 30;
            }

            return View();

        }
      
    }
}
