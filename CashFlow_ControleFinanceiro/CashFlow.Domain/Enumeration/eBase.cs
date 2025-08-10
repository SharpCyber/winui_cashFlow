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
        Teste = 1,
        Dashboard = 2,
        Transacao = 3,
        Investimento = 4,
        TransacaoRegistro = 5
    }
    public enum eDialogo
    {
        Nenhuma = 0,
        AtivoFinanceiro = 1,
        EntidadeFinanceira = 2,
        Categoria = 3,
    }

    public enum eTipoOperacao
    {
        Nenhuma = 0,
        Visualizar = 1,
        Adicionar = 2,
        Salvar = 3,
        Alterar = 4,
        Deletar = 5,
        Cancelar = 6,
        Confirmar = 7
    }
}
