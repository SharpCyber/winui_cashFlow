using CashFlow.Data;
using CashFlow.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
