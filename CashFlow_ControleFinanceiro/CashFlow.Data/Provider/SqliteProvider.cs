using Microsoft.Data.Sqlite;
using Windows.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Data.Provider
{
    internal static class SqliteProvider
    {
        private const string NOME_APLICACAO = "CashFlow";
        private const string NOME_ARQUIVO_PADRAO = "{0}_dbsqlite.db";

        public static IDbConnection CriarConexao()
        {
            string caminhoBanco = ObterCaminhoPadraoBanco();
            CriarDiretorioSeNaoExistir(caminhoBanco);

            string connectionString = $"Data Source={caminhoBanco}";
            var conexao = new SqliteConnection(connectionString);

            TestarConexao(conexao);

            return conexao;
        }

        private static string ObterCaminhoPadraoBanco()
        {
            string pastaBase = ApplicationData.Current.LocalFolder.Path;
            string pastaApp = Path.Combine(pastaBase, NOME_APLICACAO);
            string nomeArquivo = string.Format(NOME_ARQUIVO_PADRAO, SanitizeFileName(NOME_APLICACAO));

            return Path.Combine(pastaApp, nomeArquivo);
        }

        private static void CriarDiretorioSeNaoExistir(string caminhoBanco)
        {
            string diretorio = Path.GetDirectoryName(caminhoBanco);

            if (!Directory.Exists(diretorio))
            {
                try
                {
                    Directory.CreateDirectory(diretorio);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"Não foi possível criar o diretório para o banco de dados em {diretorio}", ex);
                }
            }
        }

        private static void TestarConexao(SqliteConnection conexao)
        {
            try
            {
                conexao.Open(); 
                using (var cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' LIMIT 1;";
                    cmd.ExecuteScalar();
                }
            }
            catch (SqliteException ex)
            {
                throw new InvalidOperationException($"O arquivo de banco de dados '{Path.GetFileName(conexao.DataSource)}' está corrompido ou não é um banco SQLite válido.", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao testar a conexão com o banco de dados.", ex);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }
        }

        private static string SanitizeFileName(string nome)
        {
            var invalidos = Path.GetInvalidFileNameChars();
            foreach (char c in invalidos)
                nome = nome.Replace(c, '_');
            return nome;
        }
    }
}