using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using Test.Models;

namespace Test.Models.Service
{
    public class EntityService<T> : IBase<T> where T : class
    {

        DbSet<T> EntitySet;
        private TestEntities entity;

        public EntityService(TestEntities entity)
        {
            this.entity = entity;
            EntitySet = entity.Set<T>();
        }


        public List<T> Get()
        {
            return EntitySet.ToList();
        }


        public T GetById(int id)
        {
            return EntitySet.Find(id);
        }


        public void Create(T dataObject)
        {
            EntitySet.Add(dataObject);
        }

        public void Update(T dataObject)
        {
            EntitySet.Attach(dataObject);
            entity.Entry(dataObject).State = EntityState.Modified;
        }

        public void Delete(T dataObject)
        {
            if (entity.Entry(dataObject).State == EntityState.Detached)
            {
                EntitySet.Attach(dataObject);
            }
            EntitySet.Remove(dataObject);

        }

        public void Reload(T dataObject)
        {
            entity.Entry(dataObject).Reload();
        }


    }
}