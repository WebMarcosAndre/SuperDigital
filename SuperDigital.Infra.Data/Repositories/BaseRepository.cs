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

        protected SqlContext context;

        protected DbSet<T> dbSet;

        public BaseRepository(SqlContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var entry = context.Entry(entity);
            dbSet.Attach(entity);
            entry.State = EntityState.Modified;
       
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Remove(entity);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

}
