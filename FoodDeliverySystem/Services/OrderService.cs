using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class OrderService : AbstractService<Order>
    {
        private OrderService()
        {
            container = new List<Order>();
        }

        public IEnumerable<Order> GetOrdersByUserID(string id)
        {
            return container.Where(a => a.UserID == id);
        }

        static OrderService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static OrderService GetInstance()
        {
            if (instance == null)
            {
                instance = new OrderService();
            }
            return instance;
        }
    }
}