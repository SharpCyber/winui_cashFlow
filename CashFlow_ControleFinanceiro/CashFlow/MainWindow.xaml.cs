using System;
using WinRT.Interop;
using CashFlow.Application;
using CashFlow.Domain.Enumeration;
using CashFlow.Views;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CashFlow
{
    public sealed partial class MainWindow : Window
    {
        #region Propriedades
        private const int Largura = 600;
        private const int Altura = 700;
        private AppWindow m_AppWindow;
        private NavigationViewItem paginaAtiva;
        private bool popupAtivo = false;
        #endregion

        #region Construtor
        public MainWindow()
        {
            this.InitializeComponent();

            DefinirPadraoUI();

            CashFlow.Application.ConfiguracaoServicos.Iniciar();
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
        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            paginaAtiva = nviDashBoard;
            NavView.SelectedItem = paginaAtiva;
            Configuracao.AbrirTela(ePagina.Dashboard, this.ContentFrame);
        }
        private async void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null) return;

            var itemTag = item.Tag.ToString();
            switch (itemTag)
            {
                case "Dashboard":
                    paginaAtiva = nviDashBoard;
                    popupAtivo = false;
                    Configuracao.AbrirTela(ePagina.Dashboard, this.ContentFrame); 
                    break;
                case "Transacao":
                    paginaAtiva = nviTransacaoPage;
                    popupAtivo = false;
                    Configuracao.AbrirTela(ePagina.Transacao, this.ContentFrame); 
                    break;
                case "Investimento":
                    paginaAtiva = nviInvestimentoPage;
                    popupAtivo = false;
                    Configuracao.AbrirTela(ePagina.Investimento, this.ContentFrame); 
                    break;
                case "EntidadeFinanceira":
                    popupAtivo = true;
                    await Configuracao.AbrirDialog(eDialogo.EntidadeFinanceira, this.Content.XamlRoot);
                    NavView.SelectedItem = paginaAtiva;
                    break;
                case "Categoria":
                    popupAtivo = true;
                    await Configuracao.AbrirDialog(eDialogo.Categoria, this.Content.XamlRoot);
                    NavView.SelectedItem = paginaAtiva;
                    break;
                case "AtivoFinanceiro":
                    popupAtivo = true;
                    await Configuracao.AbrirDialog(eDialogo.AtivoFinanceiro, this.Content.XamlRoot);
                    NavView.SelectedItem = paginaAtiva;
                    break;
            }
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
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(wndId);
        }
        #endregion
    }
}
