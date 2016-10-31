using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class RaitingService : AbstractService<Raiting>
    {
        #region Services

        static CommentTypeService _commentTypeService;
        public static CommentTypeService CommentTypeService
        {
            get
            {
                if (_commentTypeService == null)
                {

                    _commentTypeService = CommentTypeService.GetInstance();
                }
                return _commentTypeService;
            }
            private set
            {
                _commentTypeService = value;
            }
        }

        #endregion


        private RaitingService()
        {
            container = new List<Raiting>()
            {
                new Raiting()
                {
                    ID=1,
                    score=1,
                    Comment="დააგვიანეს",
                    
                    CompanyID=1,
                    CommentTypeID=2,

                    CommentType=CommentTypeService.FindByID(2)
                },

                new Raiting()
                {
                    ID=2,
                    score=1,
                    Comment="ბანძები ხართ ძააან",
                    
                    CompanyID=1,
                    CommentTypeID=3,

                    CommentType=CommentTypeService.FindByID(3)
                }
            };
        }

        static RaitingService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static RaitingService GetInstance()
        {
            if (instance == null)
            {
                instance = new RaitingService();
            }
            return instance;
        }

        public IEnumerable<Raiting> GetRaitingsByCompanyID(int id)
        {
            return container.Where(a => a.CompanyID == id);
        }

    }
}