using System;
using System.Collections.Generic;

namespace SuperDigital.Domain.Entities
{
    public class Conta : BaseEntity
    {
       
        public decimal Saldo { get; set; }

        public ICollection<Lancamento> Lancamentos { get; set; }
    }
}
