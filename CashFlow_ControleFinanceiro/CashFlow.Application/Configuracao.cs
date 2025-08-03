using CashFlow.Data;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Extension;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Entity;

namespace CashFlow.Application
{
    public static class Configuracao
    {
        public static void Iniciar()
        {
            RegistrarEntidades();
        }
        public static void RegistrarEntidades()
        {
            var uow = Bootstrap.ServiceProvider.GetRequiredService<IUnitOfWork>();
            //uow.Connection.CriarTabela(typeof (TipoTransacao));
            //uow.Connection.CriarTabela(typeof (Usuario));
            //uow.Connection.CriarTabela(typeof (TipoEntidadeFinanceira));
            //uow.Connection.CriarTabela(typeof(Categoria));
            //uow.Connection.CriarTabela(typeof(EntidadeFinanceira));
            //uow.Connection.CriarTabela(typeof(Transacao));
            //uow.Connection.CriarTabela(typeof(TipoInvestimento));
            //uow.Connection.CriarTabela(typeof(Ativo));
            //uow.Connection.CriarTabela(typeof(DetalheInvestimento));
            uow.Connection.CriarTabela(typeof(Provento));
        }
    }
}
