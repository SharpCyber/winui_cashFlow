using CashFlow.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Entity
{
    [Entidade("DetalheInvestimento")]
    public class DetalheInvestimento
    {
        [ChavePrimaria]
        public int PK_DetalheInvestimento { get; set; }

        [Unico, Obrigatorio, Relacionamento("Transacao", "PK_Transacao")]
        public int FK_Transacao { get; set; }

        [Obrigatorio, Relacionamento("AtivoFinanceiro", "PK_AtivoFinanceiro")]
        public int FK_Ativo { get; set; }

        [Obrigatorio]
        public decimal QuantidadeCotas { get; set; }

        [Obrigatorio]
        public decimal ValorUnitario { get; set; }

        public decimal? Imposto { get; set; } = 0;

        public decimal? OutrosCustos { get; set; } = 0;
    }
}
