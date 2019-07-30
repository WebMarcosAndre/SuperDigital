using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SuperDigital.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly SqlContext context;

        public UnitOfWork(SqlContext _context)
        {
            context = _context;
        }
        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();   
        }
        public IDbContextTransaction BeginTransaction(){ 
            return context.Database.BeginTransaction();
        }
    }
}
