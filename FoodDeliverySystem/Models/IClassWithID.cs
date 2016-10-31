using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Models
{
    public interface IClassWithID
    {
        int ID { get; set; }
    }
}