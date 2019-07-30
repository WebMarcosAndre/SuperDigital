using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Interfaces.Repositories;
using SuperDigital.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Infra.Data.Repositories
{
    public class ContaRepository :BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(SqlContext context) : base(context) { }
    }
}
