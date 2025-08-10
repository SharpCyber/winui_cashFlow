using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Extension
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Obtém o valor de uma propriedade e o converte para um tipo específico.
        /// </summary>
        /// <typeparam name="T">Tipo de retorno esperado.</typeparam>
        /// <param name="objeto">Objeto do qual a propriedade será extraída.</param>
        /// <param name="nomePropriedade">Nome da propriedade a ser extraída.</param>
        /// <param name="valorPadrao">Valor padrão a ser retornado caso a conversão falhe.</param>
        /// <returns>Valor convertido para o tipo `T` ou o valor padrão.</returns>
        public static T ObterPropriedade<T>(this object objeto, string nomePropriedade, T valorPadrao = default)
        {
            if (objeto == null || string.IsNullOrWhiteSpace(nomePropriedade))
                return valorPadrao;

            PropertyInfo propriedade = objeto.GetType().GetProperty(nomePropriedade);

            object valor = propriedade?.GetValue(objeto); ;
            if (valor == null)
                return valorPadrao;

            try
            {
                return (T)Convert.ChangeType(valor, typeof(T));
            }
            catch
            {
                return valorPadrao;
            }
        }
    }
}
