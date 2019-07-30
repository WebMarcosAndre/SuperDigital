using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Infra.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
        IDbContextTransaction BeginTransaction();
    }
}
