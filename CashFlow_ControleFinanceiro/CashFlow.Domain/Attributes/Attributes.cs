using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ChavePrimaria : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Obrigatorio : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Editavel : Attribute
    {
        public bool HabilitarEdicao { get; set; } = true;

        public Editavel(bool habilitar = true)
        {
            HabilitarEdicao = habilitar;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class UnicoAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Relacionamento : Attribute
    {
        public string Tabela { get; }
        public string ChavePrimaria { get; }

        public Relacionamento(string tabela, string chavePrimaria)
        {
            Tabela = tabela;
            ChavePrimaria = chavePrimaria;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class EntidadeAttribute : Attribute
    {
        public string NomeTabela { get; }

        public EntidadeAttribute(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class SemAutoIncrementoAttribute : Attribute
    {
    }
}
