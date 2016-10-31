using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class GeneralProductService : AbstractService<GeneralProduct>
    {
        private GeneralProductService()
        {
            container = new List<GeneralProduct>()
                {
                    new GeneralProduct()
                    {
                        ID = 1,
                        Name ="მწვადი",
                        GeneralDescription="მწვადი"
                    },

                    new GeneralProduct()
                    {
                        ID = 2,
                        Name ="კიტრისა და პომიდვრის სალათა",
                        GeneralDescription="კიტრისა და პომიდვრის სალათა"
                    },

                    new GeneralProduct()
                    {
                        ID = 3,
                        Name ="ხინკალი",
                        GeneralDescription="ხორცი და პურისგან მიღებული კერძი"
                    },

                    new GeneralProduct()
                    {
                        ID = 4,
                        Name ="ხაჭაპური",
                        GeneralDescription="ხორცი და პურისგან მიღებული კერძი"
                    },

                    new GeneralProduct()
                    {
                        ID = 5,
                        Name ="ლობიანი",
                        GeneralDescription="ხორცი და პურისგან მიღებული კერძი"
                    },

                    new GeneralProduct()
                    {
                        ID = 6,
                        Name ="ლობიო",
                        GeneralDescription="ხორცი და პურისგან მიღებული კერძი"
                    }
                };
        }


        static GeneralProductService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static GeneralProductService GetInstance()
        {
            if (instance == null)
            {
                instance = new GeneralProductService();
            }
            return instance;
        }

    }
}