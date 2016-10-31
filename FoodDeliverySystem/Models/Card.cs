using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Models
{
    public class Card : IClassWithID
    {
        public int ID { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }

        decimal _balance=24.04M;
        public decimal Balance { get { return _balance; } set { _balance = value; } }
    }
}