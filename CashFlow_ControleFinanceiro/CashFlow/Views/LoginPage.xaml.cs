using CashFlow.Domain.Interfaces.ViewModels;
using CashFlow.ViewModel.MainWindow;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace CashFlow.Views
{
    public sealed partial class LoginPage : Page
    {
        private IMainWindowViewModel _mainWindowViewModel;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.ExibirMenuNavegacao = Visibility.Visible;
            (_mainWindowViewModel as MainWindowViewModel)?.NavegarPara(Domain.Enumeration.eTela.TransacaoPage);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is IMainWindowViewModel viewModel)
            {
                _mainWindowViewModel = viewModel;
            }
        }
    }
}
