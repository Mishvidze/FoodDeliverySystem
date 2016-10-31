using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FoodDeliverySystem.Models
{
    public class Product : IClassWithID
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        [Display(Name="პროდუქტი")]
        public string Name { get; set; }
        [Display(Name = "ღირებულება")]
        public decimal Cost { get; set; }
        public int ProductCategoryID { get; set; }
        [Display(Name = "მომზადების დრო")]
        public int CookingTime { get; set; } // in minutes
        public int GeneralProductID { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Company Company { get; set; }
        public virtual GeneralProduct GeneralProduct { get; set; }

    }
}