using System;
using CashFlow.Data;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Interfaces;
using CashFlow.InfraData.Repository;
using CashFlow.ViewModel.CategoriaViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CashFlow.Application
{
    public static class Bootstrap
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static void Iniciar()
        {
            try
            {
                var host = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) => RegistrarServicos(services))
                    .Build();

                ServiceProvider = host.Services;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro na inicialização: {ex}");
            }
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ITipoTransacaoRepository, TipoTransacaoRepository>();

            services.AddSingleton<ICategoriaDialogViewModel, CategoriaDialogViewModel>();
        }
    }
}
