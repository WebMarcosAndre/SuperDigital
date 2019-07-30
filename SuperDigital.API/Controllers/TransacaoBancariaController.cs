using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperDigital.Domain;
using SuperDigital.Domain.Interfaces.Services;
using SuperDigital.Infra.Data.UnitOfWork;

namespace SuperDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoBancariaController : ControllerBase
    {
        protected IUnitOfWork unitOfWork;
        protected readonly ITransacaoBancariaService transacao;
        public TransacaoBancariaController(IUnitOfWork _unitOfWork, ITransacaoBancariaService _transacao)        
        {
            unitOfWork = _unitOfWork;
            transacao = _transacao;
        }

        [HttpPost]
        [ProducesResponseType(typeof(StatusCodeResult), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        public StatusCodeResult EfetuarTransacao(TransacaoRequest transacaoRequest) {
            try {

                transacao.EfetuarTransacao(transacaoRequest);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception) {
                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}