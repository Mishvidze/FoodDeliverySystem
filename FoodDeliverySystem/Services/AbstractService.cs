using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public abstract class AbstractService<T> where T : class, IClassWithID
    {
        protected List<T> container { get; set; }

        virtual public IEnumerable<T> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Set<T>().ToList();
            }

        }

        virtual public T Add(T item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Set<T>().Add(item);
                ctx.SaveChanges();
                return item;
            }
        }

        virtual public T FindByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Set<T>().Find(id);
            }
        }

        virtual public int Delete(T obj)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = this.FindByID(obj.ID);
                ctx.Set<T>().Attach(item);

                ctx.Entry(item).State = EntityState.Deleted;
                return ctx.SaveChanges();
            }
        }

        virtual public T Update(T item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();

                return item;
            }
        }

    }
}