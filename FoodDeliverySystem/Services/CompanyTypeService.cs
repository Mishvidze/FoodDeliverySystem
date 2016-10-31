using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class CompanyTypeService : AbstractService<CompanyType>
    {
        private CompanyTypeService()
        {
            container = new List<CompanyType>()
                {
                    new CompanyType()
                    {
                        ID=1,
                        CompanyTypeName="ქართული"
                    },

                    new CompanyType()
                    {
                        ID=2,
                        CompanyTypeName="ევროპული"
                    },

                    new CompanyType()
                    {
                        ID=3,
                        CompanyTypeName="პიცერია"
                    },

                    new CompanyType()
                    {
                        ID=4,
                        CompanyTypeName="სწრაფი კვება"
                    },

                };
        }


        static CompanyTypeService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CompanyTypeService GetInstance()
        {
            if (instance == null)
            {
                instance = new CompanyTypeService();
            }
            return instance;
        }
    }
}