using FoodDeliverySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.AdditionalClasses
{
    [NotMapped]
    public class SimilarCompany : CompanyViewModel
    {
        [Display(Name="დამზადების დრო")]
        public int CookingTime { get; set; }
        [Display(Name = "ღირებულება")]
        public decimal TotalCost { get; set; }

    }
}