using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class ProductCategorySevice : AbstractService<ProductCategory>
    {
        private ProductCategorySevice()
        {
            container = new List<ProductCategory>
            {
                new ProductCategory()
                {
                    ID=1,
                    Name="ცომეული"
                },

                new ProductCategory()
                {
                    ID=2,
                    Name="ცხელი კერძი"
                },

                new ProductCategory()
                {
                    ID=3,
                    Name="სალათები"
                },

                new ProductCategory()
                {
                    ID=4,
                    Name="სასმელები"
                }
            };
        }

        static ProductCategorySevice instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ProductCategorySevice GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductCategorySevice();
            }
            return instance;
        }
    }
}