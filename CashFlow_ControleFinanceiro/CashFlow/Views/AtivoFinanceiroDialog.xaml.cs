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
    public sealed partial class AtivoFinanceiroDialog : ContentDialog
    {
        #region Interfaces
        #endregion

        #region Propriedades
        #endregion

        #region Construtor
        public AtivoFinanceiroDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void AtivoFinanceiro_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
        #endregion

        #region Metodos
        #endregion

        private void AtivoFinanceiro_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {

        }
    }
}
