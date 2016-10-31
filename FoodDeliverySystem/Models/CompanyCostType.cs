using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Models
{
    public class CompanyCostType : IClassWithID
    {
        public int ID { get; set; }
        [Display(Name = "ღირებულების ტიპი")]
        public string CostType { get; set; }
    }
}