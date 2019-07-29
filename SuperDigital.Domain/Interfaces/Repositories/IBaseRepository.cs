using SuperDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDigital.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
