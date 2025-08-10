using CashFlow.Data;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Extension;
using CashFlow.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application
{
    public static class ConfiguracaoServicos
    {
        public static void Iniciar()
        {
            RegistrarEntidades();
        }
        public static void RegistrarEntidades()
        {
            var uow = Bootstrap.ServiceProvider.GetRequiredService<IUnitOfWork>();
            uow.Connection.CriarTabela(typeof(Usuario));
            //uow.Connection.CriarTabela(typeof(TipoEntidadeFinanceira));
            //uow.Connection.CriarTabela(typeof(Categoria));
            //uow.Connection.CriarTabela(typeof(EntidadeFinanceira));
            //uow.Connection.CriarTabela(typeof(TipoTransacao));
            //uow.Connection.CriarTabela(typeof(Transacao));
            //uow.Connection.CriarTabela(typeof(TipoInvestimento));
            //uow.Connection.CriarTabela(typeof(AtivoFinanceiro));
            //uow.Connection.CriarTabela(typeof(DetalheInvestimento));
            //uow.Connection.CriarTabela(typeof(Provento));
        }

        public static void Teste4()
        {
            //aaaa
        }

        public static void Teste3()
        {
            // testeaaaa
        }

        public static void Teste6()
        {
            // teste 6
        }
    }
}
