using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.AdditionalClasses
{
    public class OrderedProduct
    {
        public string ProductCode { get; set; }
        public int ProductQuantity { get; set; }
        public int CompanyID { get; set; }
        public decimal Price { get; set; }
    }
}