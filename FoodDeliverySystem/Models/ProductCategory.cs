using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FoodDeliverySystem.Models
{
    public class ProductCategory : IClassWithID
    {
        public int ID { get; set; }
        [Display(Name = "პროდუქტის კატეგორია")]
        public string Name { get; set; }
    }
}
