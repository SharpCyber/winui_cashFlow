using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;


namespace CashFlow.Views
{
    public sealed partial class EntidadeFinanceiraDialog : ContentDialog
    {
        #region Interfaces
        #endregion

        #region Propriedades
        #endregion

        #region Construtor
        public EntidadeFinanceiraDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void EntidadeFinanceira_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
        private void EntidadeFinanceira_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {

        }
        #endregion

        #region Metodos
        #endregion
    }
}
