using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class ProductPriceHistoryService : AbstractService<ProductPriceHistory>
    {
        static ProductService _productService;
        public static ProductService ProductService
        {
            get
            {
                if (_productService == null)
                {

                    _productService = ProductService.GetInstance();
                }
                return _productService;
            }
            private set
            {
                _productService = value;
            }
        }

        private ProductPriceHistoryService()
        {
            container = new List<ProductPriceHistory>();
        }

        static ProductPriceHistoryService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ProductPriceHistoryService GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductPriceHistoryService();
            }
            return instance;
        }

        internal Decimal GetProductPriceByDate(int realProductID, DateTime orderDate)
        {

            decimal priceOld = 0;
            decimal priceNew = 0;
            var allPricesForTheProducts = this.GetAll().Where(a => a.ProductID == realProductID ).OrderBy(a => a.StartDate);
            foreach (var item in allPricesForTheProducts)
            {
                priceNew = item.Price;
                if (orderDate < item.StartDate && realProductID==13)
                    return priceOld; 
                priceOld = priceNew;
            }

            return priceNew;
        }
    }
}