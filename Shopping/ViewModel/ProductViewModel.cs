using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Shopping.ViewModel
{
    public class ProductViewModel
    {
        public string Product_id { get; set; }

        public string Product_name { get; set; }
       
        public string type { get; set; }
       
        public string Product_description { get; set; }
       
        public float Price { get; set; }

       
        public byte[] Pimage { get; set; }
       
    }
}
