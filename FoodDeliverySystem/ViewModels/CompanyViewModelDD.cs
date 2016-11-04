using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliverySystem.ViewModels
{
    public class CompanyViewModelDD
    {
        public int ID { get; set; }
        public int CompanyTypeID { get; set; }
        public int CompanyCostTypeID { get; set; }

        public IEnumerable<SelectListItem> CompanyTypes { get; set; }
        public IEnumerable<SelectListItem> CompanyCostTypes { get; set; }
        
        [Display(Name = "კომპანიის სახელი")]
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}