using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.ViewModels
{
    public class CompanyViewModel
    {
        public int ID { get; set; }
        [Display(Name = "კომპანიის სახელი")]
        public string Name { get; set; }
        [Display(Name = "ლოგო")]
        public byte[] Logo { get; set; }
        [Display(Name = "საშუალო რეიტინგი")]
        public double AvarageRating { get; set; }
        [Display(Name = "ხმების რაოდენობა")]
        public int Votes { get; set; }

    }
}