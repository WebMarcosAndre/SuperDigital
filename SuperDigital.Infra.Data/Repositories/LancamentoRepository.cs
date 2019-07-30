using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Interfaces.Repositories;
using SuperDigital.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Infra.Data.Repositories
{
    public class LancamentoRepository : BaseRepository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(SqlContext context) : base(context) { }



    }
}
