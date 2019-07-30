using SuperDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDigital.Domain.Interfaces.Services
{
    public interface ITransacaoBancariaService
    {
        void EfetuarTransacao(TransacaoRequest transacao);

    }
}
