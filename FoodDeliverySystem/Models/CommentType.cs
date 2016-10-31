using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Models
{
    public class CommentType : IClassWithID
    {
        public int ID { get; set; }
        [Display(Name = "კომენტარის ტიპი")]
        public string Type { get; set; }
    }
}