using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class ProductMap : IProductMap
    {
        [Key]
        [Required]
        public string TrackId { get; set; }

        public string PLocation { get; set; }
        public string? Product_id { get; set; }
        [ForeignKey("Product_id")]
        public virtual Product product { get; set; }
    }
}
