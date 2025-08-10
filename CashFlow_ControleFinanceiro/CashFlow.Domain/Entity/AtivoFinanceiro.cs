using CashFlow.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Entity
{
    [Entidade("AtivoFinanceiro")]
    public class AtivoFinanceiro
    {
        [ChavePrimaria]
        public int PK_AtivoFinanceiro { get; set; }

        [Obrigatorio, Unico]
        public string Codigo { get; set; }

        public string Nome { get; set; }

        [Obrigatorio, Relacionamento("TipoInvestimento", "PK_TipoInvestimento")]
        public int FK_TipoInvestimento { get; set; }

        [Obrigatorio, Relacionamento("Usuario", "PK_Usuario")]
        public int FK_Usuario { get; set; }

        [Obrigatorio]
        public bool Ativo { get; set; } = true;
    }
}
