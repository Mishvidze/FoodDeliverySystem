using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public abstract class AbstractService<T> where T : IClassWithID
    {
        protected List<T> container { get; set; }

        virtual public IEnumerable<T> GetAll()
        {
            return container;
        }

        public void Add(T item)
        {
            if (container.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                item.ID = container.Max(a => a.ID) + 1;
            }
            container.Add(item);
        }

        public T FindByID(int id)
        {
            var r = container.SingleOrDefault(a => a.ID == id);
            return r;
        }

        public void Delete(T item)
        {
            int ind = container.FindIndex(a => a.ID == item.ID);
            container.RemoveAt(ind);
        }

        virtual public void Update(T item)
        {
            var currentItem = FindByID(item.ID);

            var propertyInfos = typeof(T).GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                var t = typeof(string).IsValueType;

                var b = (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType.IsPrimitive);
                if (b && propertyInfo.Name != "ID")
                {
                    var propValue = propertyInfo.GetValue(item);
                    propertyInfo.SetValue(currentItem, propValue);
                }
            }

        }

    }
}