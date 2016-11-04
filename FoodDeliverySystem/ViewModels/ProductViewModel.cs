using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliverySystem.ViewModels
{
    public class ProductViewModel
    {
            public int ID { get; set; }
            public int CompanyID { get; set; }
            public int ProductCategoryID { get; set; }
            public int GeneralProductID { get; set; }

            public IEnumerable<SelectListItem> Companies { get; set; }
            public IEnumerable<SelectListItem> ProductCategories { get; set; }
            public IEnumerable<SelectListItem> GeneralProducts { get; set; }

            public string Name { get; set; }
            public decimal Cost { get; set; }
            public int CookingTime { get; set; } // in minutes

    }
}