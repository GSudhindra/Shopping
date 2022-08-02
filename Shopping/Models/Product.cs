using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "Please enter user id *")]
        [StringLength(4, ErrorMessage= "Product id should not exceed the 4 characters")]
        public string Product_id { get; set; }
       
        [Required(ErrorMessage ="Every Product should have name")]
        [Display(Name ="Product")]
        public string Product_name { get; set; }
        [Required(ErrorMessage ="Product should belongs to some category")]
        public string type { get; set; }
        [Display(Name ="Product Description")]
        public string Product_description { get; set; }
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Display(Name = "Product Image")]
        [NotMapped]
        public IFormFile Pimage { get; set; } // newly added column
        [Display(Name ="Image Name")]
        public string ImageName { get; set; }
        public string Seller_id { get; set; }
        [ForeignKey("Seller_id")]
        public virtual Seller seller { get; set; }
        
        
        public virtual ICollection<ProductMap> ProductMap { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
