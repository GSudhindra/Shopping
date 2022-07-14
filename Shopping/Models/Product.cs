using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "Please enter user id *")]
        [StringLength(4, ErrorMessage= "Product id should not exceed the 4 characters")]
        public string Product_id { get; set; }
       
        [Required(ErrorMessage ="Every Product should have name")]
        public string Product_name { get; set; }
        [Required(ErrorMessage ="Product should belongs to some category")]
        public string type { get; set; }
        public string Product_description { get; set; }
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        [Display(Name ="Product Image")]

        public string Pimage { get; set; }
        public virtual Seller Seller_idNavigation { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
 
       
    }
}
