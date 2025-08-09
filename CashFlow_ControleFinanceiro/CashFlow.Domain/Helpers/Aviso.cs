using CashFlow.Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Data.Text;

namespace CashFlow.Domain.Helpers
{
    public static class Aviso
    {
        /// <summary>
        /// Cria e exibe um painel de aviso dentro de um container específico.
        /// </summary>
        /// <param name="container">O painel (StackPanel, Grid, etc.) que receberá o aviso.</param>
        /// <param name="mensagem">A mensagem a ser exibida no aviso.</param>
        /// <param name="tipoMensagem">Define que tipo de cor será atribuida ao aviso.</param>
        public static void Mostrar(Panel container, string mensagem, eTipoMensagem tipoMensagem, TextWrapping textWrapping = TextWrapping.NoWrap)
        {
            container.Children.Clear();

            var spAviso = new StackPanel
            {
                Background = Application.Current.Resources["Cinza13"] as Brush,
                BorderBrush = Application.Current.Resources[ObterCorPorTipoDeMensagem(tipoMensagem)] as Brush,
                BorderThickness = new Thickness(6, 0, 6, 0),
                CornerRadius = new CornerRadius(4),
                Margin = new Thickness(0)
            };

            var txtAviso = new TextBlock
            {
                Text = mensagem,
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(10),
                TextWrapping = textWrapping
            };

            spAviso.Children.Add(txtAviso);
            container.Children.Add(spAviso);
            container.Visibility = Visibility.Visible;
        }

        private static string ObterCorPorTipoDeMensagem(eTipoMensagem tipoMensagem)
        {
            string cor = "";

            switch (tipoMensagem)
            {
                case eTipoMensagem.Informacao: cor = "Azul2"; break; 
                case eTipoMensagem.Confirmacao: cor = "Verde2"; break; 
                case eTipoMensagem.Aviso: cor = "Amarelo"; break; 
                case eTipoMensagem.Erro: cor = "Vermelho3"; break; 
                default: cor = "Cinza13"; break;
            }

            return cor;
        }

        public static void Ocultar(Panel container)
        {
            container.Children.Clear();
            container.Visibility = Visibility.Collapsed;
        }
    }
}
