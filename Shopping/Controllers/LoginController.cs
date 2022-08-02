using Shopping.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Routing;

namespace Shopping.Controllers
{
    public class LoginController : Controller 
    {
        private readonly shopContext db;
        private readonly ISession session;
        public LoginController(shopContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Index()
        {
            ViewBag.Username=HttpContext.Session.GetString("Username");
            return View(db.Sellers.ToList());
        }
      
       
        public IActionResult login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult login(Seller obj)
        {
            var result = (from i in db.Sellers where i.Seller_id == obj.Seller_id
                                                     && i.Password == obj.Password select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("Username", result.Seller_name);
                return RedirectToAction("Index", "Sellers");

            }
            else
                return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(Seller u)
        {
            db.Sellers.Add(u);
            db.SaveChanges();
            return RedirectToAction("login");
        }
        public IActionResult CustomerRegister()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CustomerRegister(Customer u)
        {
            ViewBag.age = u.age;
            HttpContext.Session.SetInt32("age",u.age);
            db.Customers.Add(u);
            db.SaveChanges();
            return RedirectToAction("Customerlogin");
        }
        public IActionResult Customerlogin()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Customerlogin(Customer obj)
        {
            var result = (from i in db.Customers where i.Customer_id == obj.Customer_id && i.Password == obj.Password select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("Username", result.Customer_name);
                

            }
            var routeValues = new RouteValueDictionary {
            { "id", result.Customer_id }
           
            };
            return RedirectToAction("Details", "Customers",routeValues);
        }


    }
}