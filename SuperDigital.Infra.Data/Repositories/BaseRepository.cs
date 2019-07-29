using Microsoft.EntityFrameworkCore;
using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Interfaces.Repositories;
using SuperDigital.Infra.Data.Context;
using SuperDigital.Infra.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDigital.Infra.Data.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        
        private readonly sqlContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public BaseRepository(sqlContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }

}
