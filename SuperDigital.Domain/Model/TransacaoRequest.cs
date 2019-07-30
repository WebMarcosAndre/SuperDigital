using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Domain
{
    public class TransacaoRequest
    {
        public int ContaCreditoId { get; set; }
        public int ContaDebitoId { get; set; }
        public decimal Valor { get; set; }
    }

}
