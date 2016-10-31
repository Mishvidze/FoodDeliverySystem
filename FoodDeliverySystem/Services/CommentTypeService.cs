using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class CommentTypeService : AbstractService<CommentType>
    {
        private CommentTypeService()
        {
            container = new List<CommentType>()
            {
                new CommentType()
                {
                    ID=1,
                    Type="მომსახურება"
                },

                new CommentType()
                {
                    ID=2,
                    Type="მიტანის დრო"
                },

                new CommentType()
                {
                    ID=3,
                    Type="ხარისხი"
                },
            };
        }

        static CommentTypeService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CommentTypeService GetInstance()
        {
            if (instance == null)
            {
                instance = new CommentTypeService();
            }
            return instance;
        }
    }
}