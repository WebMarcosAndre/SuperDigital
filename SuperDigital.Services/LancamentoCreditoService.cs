using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Enum;
using SuperDigital.Domain.Interfaces.Repositories;
using SuperDigital.Domain.Interfaces.Services;
using SuperDigital.Infra.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Services
{
    public class LancamentoCreditoService :  ILancamentoCreditoService
    {
        protected readonly ILancamentoRepository lancamentoRepository;
      

        public LancamentoCreditoService(ILancamentoRepository _lancamentoRepository)
        {
            lancamentoRepository = _lancamentoRepository;           
        }
        

        public void Adicionar(Conta conta, decimal valor)
        {
            Lancamento lancamento = new Lancamento
            {
                Conta = conta,
                Valor = valor,
                TipoLancamento = EnumTipoLancamento.Credito
            };
            lancamentoRepository.Insert(lancamento);
           
        }
    }
}
