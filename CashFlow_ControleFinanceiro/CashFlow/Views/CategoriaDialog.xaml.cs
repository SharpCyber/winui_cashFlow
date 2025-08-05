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
    public sealed partial class CategoriaDialog : ContentDialog
    {
        #region Interfaces
        #endregion

        #region Propriedades
        #endregion

        #region Método Construtor
        public CategoriaDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void Categoria_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
        private void Categoria_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {

        }
        #endregion

        #region Metodos
        #endregion
    }
}
