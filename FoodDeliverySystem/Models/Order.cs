using FoodDeliverySystem.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Models
{
    public class Order : IClassWithID
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int? CompanyID { get; set; }
        public int? RaitingID { get; set; }
        [Display(Name="თანხა")]
        public decimal TotalCost { get; set; }
        [Display(Name = "დავალება3")]
        public decimal TotalCost2 { get; set; } 
        [Display(Name = "შეკვეთის დრო")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "სტატუსი")]
        public int state { get; set; } // 1, 2, 3, 4


        public virtual List<OrderedProduct> Products { get; set; }
        public virtual Raiting Raiting { get; set; }
        public virtual Company Company { get; set; }
    }
}