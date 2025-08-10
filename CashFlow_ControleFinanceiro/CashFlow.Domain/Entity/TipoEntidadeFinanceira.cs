using CashFlow.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Entity
{
    [Entidade("TipoEntidadeFinanceira")]
    public class TipoEntidadeFinanceira
    {
        [ChavePrimaria, SemAutoIncremento]
        public int PK_TipoEntidadeFinanceira { get; set; }

        [Obrigatorio]
        public string Nome { get; set; }
    }
}
