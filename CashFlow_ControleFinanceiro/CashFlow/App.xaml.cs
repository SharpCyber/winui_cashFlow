using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CashFlow.Application;
using CashFlow.Domain.Enumeration;
using CashFlow.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;

namespace CashFlow
{
    public partial class App : Microsoft.UI.Xaml.Application
    {
        private Microsoft.UI.Xaml.Window? _window;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            try
            {
                Bootstrap.Iniciar();

                _window = new MainWindow();
                _window.Activate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Falha na inicialização: {ex.Message}");
            }
        }
    }
}
