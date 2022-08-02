using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shopping.Models;

namespace Shopping.ViewModels
{
    public class GeneralViewModel
    {
        
        public List<Product> products { get; set; }
        public List<Customer> customers { get; set; }
        public string TimeDisplay()
        {
            return $"The Server Time is {DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")}";
        }
    }
}