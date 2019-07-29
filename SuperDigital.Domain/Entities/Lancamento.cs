
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Entities
{
    public class Lancamento : BaseEntity
    {                                                                         

        public Conta Conta { get; set; }

        public int TipoOperacao { get; set; }

        public decimal Valor { get; set; }
    }
}
