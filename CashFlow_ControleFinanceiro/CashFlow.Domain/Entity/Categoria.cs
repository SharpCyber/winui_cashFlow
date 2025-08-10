using CashFlow.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Entity
{
    [Entidade("Categoria")]
    public class Categoria
    {
        [ChavePrimaria]
        public int PK_Categoria { get; set; }

        [Obrigatorio]
        public string Nome { get; set; }

        [Obrigatorio, Relacionamento("Usuario", "PK_Usuario")]
        public int FK_Usuario { get; set; }
    }

}
