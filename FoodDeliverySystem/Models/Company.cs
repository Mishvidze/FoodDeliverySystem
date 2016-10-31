using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Models
{
    public class Company : IClassWithID
    {
        public int ID { get; set; }
        [Display(Name = "კომპანიის სახელი")]
        public string Name { get; set; }
        public int CompanyTypeID { get; set; }
        [Display(Name = "ლოგო")]
        public byte[] Logo { get; set; }
        public int CompanyCostTypeID { get; set; }
        public DateTime RegistrationDate { get; set; } // non-editable

        public virtual CompanyType CompanyType { get; set; }
        public virtual CompanyCostType CompanyCostType{ get; set; }
        public virtual List<Raiting> Raitings { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}

