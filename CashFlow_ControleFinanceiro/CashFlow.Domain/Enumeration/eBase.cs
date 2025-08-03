using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Enumeration
{
    public enum eTipoMensagem
    {
        Informacao = 0,
        Confirmacao = 1,
        Aviso = 2,
        Erro = 3
    }
    public enum eTipoMensagemResultado
    {
        Nenhum = 0,
        OK = 1,
        Sim = 2,
        Cancelar = 3
    }
    public enum eDirecaoOrdenacao
    {
        Ascendente,
        Descendente
    }
    public enum ePagina
    {
        Nenhuma = 0,
        Dashboard = 1,
        Transacao = 2,
        Investimento = 3,
    }
    public enum eDialogo
    {
        Nenhuma = 0,
        AtivoFinanceiro = 1,
        EntidadeFinanceira = 2,
        Categoria = 3,
    }
}
