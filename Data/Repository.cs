using Contracts.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> : IRepository<T>
        where T : class, IAggregateRoot
    {
        DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public T Find(object id)
        {
            return Context.Set<T>().Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return Context.Set<T>();
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
