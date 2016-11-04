using FoodDeliverySystem.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class OrderedProductService : AbstractService<OrderedProduct>
    {
        private OrderedProductService()
        {
            container = new List<OrderedProduct>();
        }

        #region Code for single element creation
        static OrderedProductService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static OrderedProductService GetInstance()
        {
            if (instance == null)
            {
                instance = new OrderedProductService();
            }
            return instance;
        }
        #endregion
    }
}