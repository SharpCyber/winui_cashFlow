using CashFlow.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Entity
{
    [Entidade("TipoInvestimento")]
    public class TipoInvestimento
    {
        [ChavePrimaria]
        public int PK_TipoInvestimento { get; set; }

        [Obrigatorio]
        public string Nome { get; set; }
    }

}
