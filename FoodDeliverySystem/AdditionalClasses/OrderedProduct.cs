using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.AdditionalClasses
{
    
    public class OrderedProduct : IClassWithID
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        [NotMapped]
        public int CompanyID { get; set; }
        public int GeneralProductID { get; set; }
        public int RealProductID { get; set; }

        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }

        // Navigation Properties
        public virtual GeneralProduct GeneralProduct { get; set; }
        public virtual Company Company{ get; set; }
    }
}