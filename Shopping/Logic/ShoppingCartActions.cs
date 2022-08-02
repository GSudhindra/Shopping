//using Microsoft.AspNetCore.Http;
//using Shopping.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Shopping.Logic
//{
//    public class ShoppingCartActions:IDisposable
//    {
//        public string ShoppingCartId { get; set; }
//        private shopContext _db = new shopContext();
//        public const string CartSessionKey = "CartId";
//        public void AddToCart(string id)
//        {
//            ShoppingCartId = GetCartId();
//            var cartItem = _db.CartItems.SingleOrDefault(
//                c => c.CartId == ShoppingCartId
//                && c.Product_id == id);
//            if(cartItem == null)
//            {
//                //create a new cart item if no cart item exists
//                cartItem = new CartItem
//                {
//                    ItemId = Guid.NewGuid().ToString(),
//                    Product_id = id,
//                    CartId = ShoppingCartId,
//                    products = _db.Products.SingleOrDefault(
//                        p => p.Product_id == id),
//                    Quantity = 1,
//                    DateCreated = DateTime.Now

//                };
//                _db.CartItems.Add(cartItem);
//            }
//            else
//            {
//                // if item prensents in cart, then just add one.
//                cartItem.Quantity++;
//            }
//            _db.SaveChanges();
//        }
//        public void Dispose()
//        {
//            if (_db != null)
//            {
//                _db.Dispose();
//                _db = null;
//            }
//        }
//        public string GetCartId()
//        {
//            if (HttpContext.Current.Session[CartSessionKey]==null)
//            {
//                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
//                {
//                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identiy.Name;
//                }
//                else
//                {   
//                    Guid tempCartId=Guid.NewGuid();
//                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
//                }
                
//            }
//            return HttpContext.Current.Session[CartSessionKey].ToString();
//        }
//        public List<CartItem> GetCartItems()
//        {
//            ShoppingCartId=GetCartId();
//            return _db.CartItems.Where(c=>c.CartId==ShoppingCartId).ToList();
//        }
//    }
//}
