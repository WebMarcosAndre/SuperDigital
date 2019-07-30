using SuperDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Interfaces.Services
{
    public interface ILancamentoDebitoService
    {
        void Adicionar(Conta conta, decimal valor);
    }
}
