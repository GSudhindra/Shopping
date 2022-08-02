using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using Shopping.ViewModels;
using System.Linq;

namespace Shopping.Controllers
{
    public class TablesViewController : Controller
    {
        private readonly shopContext _context;

        public TablesViewController(shopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Product = _context.Products.ToList();
            var Customer = _context.Customers.ToList();
        //var Product = new List<>()
        //    {
        //        new Book {BookName = "Programming in C#"},
        //        new Book {BookName = "Programming in C++"},
        //        new Book {BookName = "Programming in Java"}
        //    };

        //        var Customer = new List<Customer>()
        //    {
        //        new Customer {CustomerName = "Zain"},
        //        new Customer {CustomerName = "Hassan"},
        //        new Customer {CustomerName = "Syed"}
        //    };

                var GeneralViewModel = new GeneralViewModel
                {
                    products = Product,
                    customers = Customer
                };

                return View(GeneralViewModel);
       
        }
    }
}
