using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class CompanyCostTypeService : AbstractService<CompanyCostType>
    {
        private CompanyCostTypeService()
        {
            container = new List<CompanyCostType>()
            {
                new CompanyCostType()
                {
                    ID=1,
                    CostType="დაბალი"
                },

                new CompanyCostType()
                {
                    ID=2,
                    CostType="საშუალო"
                },

                new CompanyCostType()
                {
                    ID=3,
                    CostType="მაღალი"
                },

            };
        }


        static CompanyCostTypeService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CompanyCostTypeService GetInstance()
        {
            if (instance == null)
            {
                instance = new CompanyCostTypeService();
            }
            return instance;
        }
    }
}