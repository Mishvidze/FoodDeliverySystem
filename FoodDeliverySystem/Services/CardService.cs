using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class CardService : AbstractService<Card>
    {
        private CardService()
        {
            container = new List<Card>();
        }

        static CardService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CardService GetInstance()
        {
            if (instance == null)
            {
                instance = new CardService();
            }
            return instance;
        }

        public bool CheckTheCard(string cardNumber){
            return lurh(cardNumber);
        }
        
        public static bool lurh(string creditCardNumber)
        {
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }

            int sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);
           
            return sumOfDigits % 10 == 0;
        }
    }
}