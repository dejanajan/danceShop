using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IDomainEntityServices<T>
        where T : class, IAggregateRoot
    {
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);

        T Find(object id);
        IList<T> FindAll();
    }
}
