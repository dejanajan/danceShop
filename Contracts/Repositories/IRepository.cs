using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        T Find(object id);

        IQueryable<T> FindAll();

        void Save();
    }
}
