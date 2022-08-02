using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public string Product_id { get; set; }
        [ForeignKey("Product_id")]

        public virtual Product products { get; set; }
        public string Customer_id { get; set; }
        [ForeignKey("Customer_id")]

        public virtual Customer customers { get; set; }
    }
}