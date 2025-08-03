using CashFlow.Data;
using CashFlow.Domain.Enumeration;
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
        }

        public static void Teste3()
        {

        }
    }
}
