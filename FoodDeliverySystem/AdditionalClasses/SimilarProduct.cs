using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.AdditionalClasses
{
    [NotMapped]
    public class SimilarProduct
    {
        public int ProductCode { get; set; }
        public int ProductQuantity { get; set; }
    }
}