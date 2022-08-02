using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Seller
    {
        [Key]
        [Required(ErrorMessage = "Please enter user id *")]
        public string Seller_id { get; set; }
        public string Seller_name { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "please enter the valid Password")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string CPassword { get; set; }
        [Required(ErrorMessage = "please enter the valid age")]
        public int age { get; set; }
        [Required(ErrorMessage = "please enter the valid phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}
