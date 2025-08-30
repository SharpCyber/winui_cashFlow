using CashFlow.Application;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces;
using CashFlow.ViewModel.MainWindowViewModel;
using CashFlow.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using Windows.Graphics;
using WinRT.Interop;

namespace CashFlow
{
    public sealed partial class MainWindow : Window
    {
        #region Interfaces
        private readonly IMainWindowVM _mainWindowVM;
        #endregion

        #region Propriedades
        private const int Largura = 800;
        private const int Altura = 600;
        private AppWindow m_AppWindow;
        private NavigationViewItem paginaAtiva;

        private bool popupAtivo = false;
        #endregion

        #region Construtor
        public MainWindow()
        {
            this.InitializeComponent();

            DefinirPadraoUI();

            _mainWindowVM = Bootstrap.ServiceProvider.GetRequiredService<IMainWindowVM>();
            MainContent.DataContext = _mainWindowVM;

            CashFlow.Application.ConfiguracaoServicos.Iniciar();
            SetWindowMinSize();
        }
        #endregion

        #region Eventos
        private async void MainWindow_Closed(object sender, WindowEventArgs args)
        {
            try
            {

            }
            catch
            {

            }
        }
        private async void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            await NavegarParaItem(nviTransacaoPage);
            NavView.SelectedItem = paginaAtiva;
        }

        private async void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null)
                return;

            await NavegarParaItem(item);
        }
        #endregion

        #region Metodos
        private void DefinirPadraoUI()
        {
            m_AppWindow = ObterAppWindowAtual();
            m_AppWindow.Title = "FlowCheck";
            m_AppWindow.SetIcon("Assets/flowcheck_icone_24.ico");

            DefinirTamanhoUI();
            CentralizarUI();

            var appWindow = ObterAppWindowAtual();
            if (appWindow != null && Microsoft.UI.Windowing.AppWindowTitleBar.IsCustomizationSupported())
            {
                var titleBar = appWindow.TitleBar;

                titleBar.BackgroundColor = Windows.UI.Color.FromArgb(255, 18, 18, 18);
                titleBar.ForegroundColor = Colors.White;

                titleBar.InactiveBackgroundColor = titleBar.BackgroundColor;
                titleBar.InactiveForegroundColor = titleBar.ForegroundColor;

                titleBar.ButtonBackgroundColor = titleBar.BackgroundColor;
                titleBar.ButtonForegroundColor = titleBar.ForegroundColor;
                titleBar.ButtonHoverBackgroundColor = Windows.UI.Color.FromArgb(255, 18, 18, 18);
                titleBar.ButtonHoverForegroundColor = titleBar.ForegroundColor;
                titleBar.ButtonPressedBackgroundColor = Windows.UI.Color.FromArgb(255, 18, 18, 18);
            }
        }
        private void DefinirTamanhoUI()
        {
            m_AppWindow.Resize(new Windows.Graphics.SizeInt32(Largura, Altura));
        }
        private void CentralizarUI()
        {
            var displayArea = DisplayArea.GetFromWindowId(m_AppWindow.Id, DisplayAreaFallback.Primary);
            var centralizacao = new Windows.Graphics.PointInt32
            {
                X = displayArea.WorkArea.X + (displayArea.WorkArea.Width - Largura) / 2,
                Y = displayArea.WorkArea.Y + (displayArea.WorkArea.Height - Altura) / 2
            };
            m_AppWindow.Move(centralizacao);
        }
        private AppWindow ObterAppWindowAtual()
        {
            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(wndId);
        }
        private void SetWindowMinSize()
        {
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);

            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
            if (appWindow == null)
            {
                return; 
            }

            var presenter = appWindow.Presenter as OverlappedPresenter;
            if (presenter == null)
            {
                return; 
            }

            presenter.PreferredMinimumHeight = Altura;
            presenter.PreferredMinimumWidth = Largura;
        }
        private void AtualizarNomeTelaAtiva(NavigationViewItem pagina)
        {
            if (pagina != null)
                _mainWindowVM.NomeTelaAtiva = ToolTipService.GetToolTip(pagina)?.ToString();
        }

        private async Task NavegarParaItem(NavigationViewItem item)
        {
            if (item == null) return;

            var tag = item.Tag.ToString();

            if (tag != null && !tag.Contains("Dialog"))
            {
                AtualizarNomeTelaAtiva(item);
                popupAtivo = false;
                paginaAtiva = item;
            }
            else
            {
                popupAtivo = true;
            }

            switch (tag)
            {
                case "Transacao":
                    Configuracao.AbrirTela(ePagina.Transacao, this.ContentFrame);
                    break;
                case "TransacaoRegistro":
                    Configuracao.AbrirTela(ePagina.TransacaoRegistro, this.ContentFrame);
                    break;
                case "EntidadeFinanceiraDialog":
                    await Configuracao.AbrirDialog(eDialogo.EntidadeFinanceira, this.Content.XamlRoot);
                    NavView.SelectedItem = paginaAtiva;
                    break;
                case "CategoriaDialog":
                    await Configuracao.AbrirDialog(eDialogo.Categoria, this.Content.XamlRoot);
                    NavView.SelectedItem = paginaAtiva;
                    break;
                case "AtivoFinanceiroDialog":
                    await Configuracao.AbrirDialog(eDialogo.AtivoFinanceiro, this.Content.XamlRoot);
                    NavView.SelectedItem = paginaAtiva;
                    break;
            }
        }
        #endregion
    }
}
