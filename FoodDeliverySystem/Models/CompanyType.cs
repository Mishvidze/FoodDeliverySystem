using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FoodDeliverySystem.Models
{
    public class CompanyType : IClassWithID
    {
        public int ID { get; set; }
        [Display(Name = "კომპანიის ტიპი")]
        public string CompanyTypeName { get; set; }
    }
}
