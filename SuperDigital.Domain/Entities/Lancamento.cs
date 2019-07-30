
using SuperDigital.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Entities
{
    public class Lancamento : BaseEntity
    {           
        public Conta Conta { get; set; }

        public decimal Valor { get; set; }

        public EnumTipoLancamento TipoLancamento {get;set;}  
    }
}

