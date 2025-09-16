using CashFlow.Data;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.ViewModels;
using CashFlow.InfraData.Repository;
using CashFlow.ViewModel;
using CashFlow.ViewModel.Ativo;
using CashFlow.ViewModel.Categoria;
using CashFlow.ViewModel.Entidade;
using CashFlow.ViewModel.MainWindow;
using CashFlow.ViewModel.TransacaoPage;
using CashFlow.ViewModel.TransacaoRegistro;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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

            RegistrarRepositorios(services);
            RegistrarViewModels(services);
        }

        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.AddSingleton<ITipoTransacaoRepository, TipoTransacaoRepository>();
        }

        private static void RegistrarViewModels(IServiceCollection services) 
        {
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
            services.AddSingleton<ICategoriaDialogViewModel, CategoriaDialogViewModel>();
            services.AddSingleton<IAtivoDialogViewModel, AtivoDialogViewModel>();
            services.AddSingleton<IEntidadeRegistroDialogViewModel, EntidadeRegistroDialogViewModel>();
            services.AddSingleton<ITransacaoRegistroViewModel, TransacaoRegistroViewModel>();
            services.AddSingleton<ITransacaoPageViewModel, TransacaoPageViewModel>();
        }
    }
}
