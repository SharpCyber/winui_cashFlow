using CashFlow.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Entity
{
    [Entidade("EntidadeFinanceira")]
    public class EntidadeFinanceira
    {
        [ChavePrimaria]
        public int PK_EntidadeFinanceira { get; set; }

        [Obrigatorio, Relacionamento("TipoEntidadeFinanceira", "PK_TipoEntidadeFinanceira")]
        public int FK_TipoEntidadeFinanceira { get; set; }

        [Relacionamento("Categoria", "PK_Categoria")]
        public int? FK_Categoria { get; set; }

        [Obrigatorio]
        public string Nome { get; set; }

        [Obrigatorio]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Obrigatorio, Relacionamento("Usuario", "PK_Usuario")]
        public int FK_Usuario { get; set; }

        [Obrigatorio]
        public bool Ativo { get; set; } = true;
    }
}
