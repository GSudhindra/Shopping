using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Customer
    {
        [Key]
        [Required(ErrorMessage = "Please enter user id *")]
        public string Customer_id { get; set; }
        public string Customer_name { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "please enter the valid Password")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string CPassword { get; set; }
        [Required(ErrorMessage = "please enter the valid age")]
        public int age { get; set; }
        public string gender { get; set; }
        [Required(ErrorMessage = "please enter the valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }
        public virtual Product Product_idNavigation { get; set; }
    }
}
