using CashFlow.Application;
using CashFlow.Domain.Enumeration;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using WinRT.Interop;

namespace CashFlow
{
    public sealed partial class MainWindow : Window
    {
        #region Propriedades
        private const int Largura = 600;
        private const int Altura = 700;
        private AppWindow m_AppWindow;
        private Type paginaAtiva;
        #endregion

        #region Construtor
        public MainWindow()
        {
            this.InitializeComponent();

            DefinirPadraoUI();

            Configuracao.Iniciar();
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
