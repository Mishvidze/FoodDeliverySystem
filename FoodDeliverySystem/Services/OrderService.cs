using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Data.Entity;

namespace FoodDeliverySystem.Services
{
    public class OrderService : AbstractService<Order>
    {
        static ProductPriceHistoryService _ProductPriceHistoryService;
        public static ProductPriceHistoryService ProductPriceHistoryService
        {
            get
            {
                if (_ProductPriceHistoryService == null)
                {

                    _ProductPriceHistoryService = ProductPriceHistoryService.GetInstance();

                }
                return _ProductPriceHistoryService;
            }
            private set
            {
                _ProductPriceHistoryService = value;
            }
        }


        ApplicationDbContext _context;
        public ApplicationDbContext context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ApplicationDbContext();
                }
                return _context;
            }
            private set
            {
                _context = value;
            }
        }

        private OrderService()
        {
            container = new List<Order>();
        }

        public override IEnumerable<Order> GetAll()
        {
            return context.Orders;
        }

        public IEnumerable<Order> GetOrdersByUserID(string id)
        {
            var context = new ApplicationDbContext();
            var resOrders = context.Orders.Where(a => a.UserID == id).Include(b=>b.Products);

            foreach (var order in resOrders)
            {
                order.TotalCost2 = 0;
                foreach (var product in order.Products) // orderedProduct
                {
                    order.TotalCost2 += ProductPriceHistoryService.GetProductPriceByDate(product.RealProductID, order.OrderDate)*product.ProductQuantity;
                }
            }
            return resOrders;
        }

        public override Order FindByID(int id)
        {
            var context = new ApplicationDbContext();

            return context.Orders.Single(a => a.ID == id);
        }

        public override Order Update(Order item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();

            return item;
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