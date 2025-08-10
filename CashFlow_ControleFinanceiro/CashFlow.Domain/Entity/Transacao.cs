using CashFlow.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Entity
{
    [Entidade("Transacao")]
    public class Transacao
    {
        [ChavePrimaria]
        public int PK_Transacao { get; set; }

        [Obrigatorio, Relacionamento("TipoTransacao", "PK_TipoTransacao")]
        public int FK_TipoTransacao { get; set; }

        [Obrigatorio, Relacionamento("EntidadeFinanceira", "PK_EntidadeFinanceira")]
        public int FK_EntidadeFinanceira { get; set; }

        [Obrigatorio]
        public decimal Valor { get; set; }

        [Obrigatorio]
        public DateTime DataTransacao { get; set; } = DateTime.Now;

        public DateTime? DataVencimento { get; set; }

        public string Observacao { get; set; }

        [Obrigatorio, Relacionamento("Usuario", "PK_Usuario")]
        public int FK_Usuario { get; set; }
    }
}
