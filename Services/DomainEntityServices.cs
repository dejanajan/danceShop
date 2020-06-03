using System;
using Model;
using Contracts;
using Contracts.Repositories;
using Contracts.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DomainEntityServices<T> : IDomainEntityServices<T>
        where T : class, IAggregateRoot
    {
        IRepository<T> _Repository;
        public DomainEntityServices(IRepository<T> repo)
        {
            _Repository = repo;
        }


        public void Add(T entity)
        {
            _Repository.Add(entity);
            _Repository.Save();
        }

        public void Delete(T entity)
        {
            _Repository.Delete(entity);
            _Repository.Save();
        }

        public void Edit(T entity)
        {
            _Repository.Edit(entity);
            _Repository.Save();
        }

        public T Find(object id)
        {
            return _Repository.Find(id);
        }

        public IList<T> FindAll()
        {
            return _Repository.FindAll().ToList();
        }


    }
}
