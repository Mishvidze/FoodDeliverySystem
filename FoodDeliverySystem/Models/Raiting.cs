using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FoodDeliverySystem.Models
{
    public class Raiting : IClassWithID
    {
        public int ID { get; set; }
        [Display(Name="ქულა")]
        public int score { get; set; }
        [Display(Name = "კომენტარი")]
        public string Comment { get; set; }

        public int CompanyID { get; set; }
        public int CommentTypeID { get; set; }

        public virtual CommentType CommentType { get; set; }
    }
}
