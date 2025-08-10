using CashFlow.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Entity
{
    [Entidade("Usuario")]
    public class Usuario
    {
        [ChavePrimaria]
        public int PK_Usuario { get; set; }

        [Obrigatorio, Unico]
        public string Email { get; set; }

        [Obrigatorio]
        public string NomeUsuario { get; set; }

        public string? LoginApi { get; set; }
        public string? Senha { get; set; }
        public string? Salt { get; set; }

        [Obrigatorio]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Obrigatorio]
        public bool Ativo { get; set; } = true;
    }

}
