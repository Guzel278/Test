using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.Models.Service
{
    public class UOW : IDisposable
    {
        private readonly TestEntities entity;
        private bool disposed;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UOW(TestEntities context)
        {
            this.entity = context;
        }

        public UOW()
        {
            entity = new TestEntities();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            entity.SaveChanges();
        }

        public void RefreshAll()
        {
            foreach (var ent in entity.ChangeTracker.Entries())
            {
                ent.Reload();
            }
        }

        public void RefreshOne<T>() where T : class
        {
            foreach (var ent in entity.ChangeTracker.Entries())
            {
                if (ent.Entity.GetType() == typeof(T))
                {
                    ent.Reload();
                }
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    entity.Dispose();
                }
            }
            disposed = true;
        }

        public IBase<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IBase<T>;
            }
            IBase<T> repo = new EntityService<T>(entity);
            repositories.Add(typeof(T), repo);
            return repo;
        }


        //работа с БД

        public List<Order> lstOrder()
        {
            List<Order> lst = new List<Order>();
            lst = entity.Orders.ToList();
            return lst;
        }

        public List<Provider> lstProvider()
        {
            List<Provider> lst = new List<Provider>();
            lst = entity.Providers.ToList();
            return lst;
        }

        public List<OrderItem> lstOrderItem(int orderId)
        {
            List<OrderItem> lst = new List<OrderItem>();
            lst = (from l in entity.OrderItems
                   where l.OrderId == orderId
                   select l).ToList();
            return lst;
        }

        //public OrderItem currentOrderItem(int orderId)
        //{
        //     OrderItem m = new OrderItem();
        //     m = entity.OrderItems.Where(t => t.OrderId == orderId);
        //    return m;
        //}
        //public Dictionary<int, string> lstProvider()
        //{
        //    Dictionary<int, string> lstProvider = new Dictionary<int, string>();
        //    lst = entity.Orders.ToList();
        //    return lst;
        //}

    }
}