using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Models
{
    public class ProductPriceHistory : IClassWithID
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }

        public Decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Company Company { get; set; }
    }
}