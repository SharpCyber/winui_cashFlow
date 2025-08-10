using CashFlow.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Entity
{
    [Entidade("Provento")]
    public class Provento
    {
        [ChavePrimaria]
        public int PK_Provento { get; set; }

        [Obrigatorio, Unico, Relacionamento("Transacao", "PK_Transacao")]
        public int FK_Transacao { get; set; }

        [Obrigatorio, Relacionamento("Ativo", "PK_Ativo")]
        public int FK_Ativo { get; set; }

        public decimal? QuantidadeCotasBase { get; set; }

        public decimal? ValorPorCota { get; set; }

        public decimal? Imposto { get; set; } = 0;

        public string Descricao { get; set; }
    }
}
