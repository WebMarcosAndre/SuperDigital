using SuperDigital.Domain;
using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Interfaces.Repositories;
using SuperDigital.Domain.Interfaces.Services;
using SuperDigital.Infra.Data.UnitOfWork;
using System;

namespace SuperDigital.Services
{
    public class TransacaoBancariaService : ITransacaoBancariaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILancamentoRepository lancamentoRepository;
        private readonly IContaRepository contaRepository;
        private readonly ILancamentoDebitoService operacaoDebito;
        private readonly ILancamentoCreditoService operacaoCredito;

        public TransacaoBancariaService(IUnitOfWork _unitOfWork,
            ILancamentoRepository _lancamentoRepository,
            IContaRepository _contaRepository,
        ILancamentoCreditoService _operacaoCreditoService,
            ILancamentoDebitoService _operacaoDebitoService)
        {
            unitOfWork = _unitOfWork;
            lancamentoRepository = _lancamentoRepository;
            contaRepository = _contaRepository;
            operacaoCredito = _operacaoCreditoService;
            operacaoDebito = _operacaoDebitoService;
        }

        public void EfetuarTransacao(TransacaoRequest transacaoRequest)
        {                                 
            Conta contaCredito = contaRepository.Get(transacaoRequest.ContaCreditoId);
            Conta contaDebito = contaRepository.Get(transacaoRequest.ContaDebitoId);

            using (var transacao = unitOfWork.BeginTransaction())
            {
                contaCredito.Saldo += transacaoRequest.Valor;
                operacaoCredito.Adicionar(contaCredito, transacaoRequest.Valor);
                contaRepository.Update(contaCredito);

                contaDebito.Saldo -= transacaoRequest.Valor;
                operacaoDebito.Adicionar(contaDebito, transacaoRequest.Valor);
                contaRepository.Update(contaDebito);

                unitOfWork.Commit();
                transacao.Commit();
            }
        }
    }
}
