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
    public enum eTela
    {
        Nenhuma = 0,
        LoginPage = 1,
        TransacaoPage = 2,
        TransacaoRegistroPage = 3,
        AtivoFinanceiroDialog = 4,
        EntidadeFinanceiraDialog = 5,
        CategoriaDialog = 6,
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
    public enum eLoginOperacao
    {
        Login = 1,
        Registrar = 2,
        RecuperarSenha = 3,
        TrocarSenha = 4,
        LoginGoogle = 5,
    }
}
