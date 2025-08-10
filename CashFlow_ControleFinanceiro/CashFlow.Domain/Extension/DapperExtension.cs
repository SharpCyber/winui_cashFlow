using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.DTO;
using CashFlow.Domain.Attributes;

namespace CashFlow.Domain.Extension
{
    public static class DapperExtension
    {
        public static bool VerificarTabelaExistente<T>(this IDbConnection connection)
        {
            Type entidade = typeof(T);
            string tabela = entidade.Name;

            string query = $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{tabela}';";

            try
            {
                var resultado = connection.ExecuteScalar<int>(query);

                return resultado > 0;
            }
            catch
            {
                return false;
            }
        }

        public static IEnumerable<EntidadeValidacao> VerificarEntidadeExiste(this IDbConnection connection, IEnumerable<Type> entidades)
        {
            var resultado = new List<EntidadeValidacao>();

            if (entidades.Count() <= 0)
                return resultado;

            if (connection == null)
                return resultado;

            foreach (var item in entidades)
            {
                var entidade = new EntidadeValidacao
                {
                    TipoEntidade = item,
                    Existe = false,
                };

                try
                {
                    string query = $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{entidade.Nome}';";

                    entidade.Existe = connection.ExecuteScalar<int>(query) > 0;
                }
                catch
                {
                    entidade.Existe = false;
                }

                resultado.Add(entidade);
            }

            return resultado;
        }

        public static T Obter<T>(this IDbConnection connection, int id)
        {
            Type entidade = typeof(T);
            string tabela = entidade.Name;

            PropertyInfo chavePrimaria = ObterChavePrimaria(entidade);
            string coluna = chavePrimaria.Name;

            string sql = $"SELECT * FROM {tabela} WHERE {coluna} = @Id";

            var ret = connection.QuerySingleOrDefault<T>(sql, new { Id = id });

            if (ret == null)
                throw new Exception("Nenhum resultado encontrado.");

            return ret;
        }

        public static IEnumerable<T> ObterLista<T>(this IDbConnection connection, string condicao = "", object parametros = null)
        {
            Type entidade = typeof(T);
            string tabela = entidade.Name;

            string sql = $"SELECT * FROM {tabela}";

            if (!string.IsNullOrWhiteSpace(condicao))
            {
                sql += $" WHERE {condicao}";
            }

            return parametros == null ? connection.Query<T>(sql) : connection.Query<T>(sql, parametros);
        }

        public static int Adicionar<T>(this IDbConnection connection, T entity, IDbTransaction transaction = null)
        {
            Type entidade = typeof(T);
            string tabela = entidade.Name;

            PropertyInfo chavePrimaria = ObterChavePrimaria(entidade);
            string coluna = chavePrimaria.Name;

            var colunas = new List<string>();
            var parametros = new DynamicParameters();

            foreach (PropertyInfo propriedade in entidade.GetProperties())
            {
                if (propriedade.GetCustomAttribute<ChavePrimaria>() != null)
                    continue;

                if (propriedade.GetCustomAttribute<Editavel>(false) != null)
                    continue;

                if (propriedade.GetCustomAttribute<Obrigatorio>() != null && propriedade.GetValue(entity) == null)
                    throw new InvalidOperationException($"A propriedade {propriedade.Name} é obrigatória e não foi preenchida.");

                var valor = propriedade.GetValue(entity);
                colunas.Add($"{propriedade.Name}");
                parametros.Add(propriedade.Name, valor);
            }

            string sql = $"INSERT INTO {tabela} ({string.Join(", ", colunas)}) VALUES ({string.Join(", ", colunas.Select(p => "@" + p))});";
            sql += "SELECT last_insert_rowid();";

            var result = connection.ExecuteScalar<int>(sql, parametros, transaction);

            if (result == 0)
            {
                throw new InvalidOperationException("Nenhuma linha foi inserida no banco de dados.");
            }

            return result;
        }

        public static int Atualizar<T>(this IDbConnection connection, T entity, IDbTransaction transaction = null)
        {
            Type entidade = typeof(T);
            string tabela = entidade.Name;

            PropertyInfo chavePrimaria = ObterChavePrimaria(entidade);
            string coluna = chavePrimaria.Name;

            var colunas = new List<string>();
            var parametros = new DynamicParameters();

            foreach (PropertyInfo propriedade in entidade.GetProperties())
            {
                if (propriedade.GetCustomAttribute<ChavePrimaria>() != null)
                    continue;

                if (propriedade.GetCustomAttribute<Editavel>(false) != null)
                    continue;

                if (propriedade.GetCustomAttribute<Obrigatorio>() != null && propriedade.GetValue(entity) == null)
                {
                    throw new InvalidOperationException($"A propriedade {propriedade.Name} é obrigatória e não foi preenchida.");
                }

                var valor = propriedade.GetValue(entity);
                colunas.Add($"{propriedade.Name} = @{propriedade.Name}");
                parametros.Add(propriedade.Name, valor);
            }

            parametros.Add("Id", chavePrimaria.GetValue(entity));

            string sql = $"UPDATE {tabela} SET {string.Join(", ", colunas)} WHERE {coluna} = @Id";

            var rowsAffected = connection.Execute(sql, parametros, transaction);

            if (rowsAffected == 0)
            {
                throw new InvalidOperationException("Nenhuma linha foi atualizada no banco de dados. Verifique se o registro existe.");
            }

            return rowsAffected;
        }

        public static int Deletar<T>(this IDbConnection connection, object id, IDbTransaction transaction = null)
        {
            Type entidade = typeof(T);
            string tabela = entidade.Name;

            PropertyInfo chavePrimaria = ObterChavePrimaria(entidade);
            string coluna = chavePrimaria.Name;

            string sqlVerificacao = $"SELECT COUNT(1) FROM {tabela} WHERE {coluna} = @Id";
            var existeRegistro = connection.ExecuteScalar<int>(sqlVerificacao, new { Id = id }, transaction) > 0;

            if (!existeRegistro)
                throw new InvalidOperationException("O registro a ser excluído não existe.");

            string sqlDeletar = $"DELETE FROM {tabela} WHERE {coluna} = @Id";

            return connection.Execute(sqlDeletar, new { Id = id }, transaction);
        }

        public static int DeletarTudo<T>(this IDbConnection connection, IDbTransaction transaction = null)
        {
            string tabela = typeof(T).Name;
            string sqlDeletarTudo = $"DELETE FROM {tabela}";
            return connection.Execute(sqlDeletarTudo, transaction: transaction);
        }

        public static bool CriarTabela(this IDbConnection connection, Type entityType, IDbTransaction transaction = null)
        {
            var atributoEntidade = entityType.GetCustomAttribute<EntidadeAttribute>();
            string tableName = atributoEntidade?.NomeTabela ?? entityType.Name;
            //string tableName = entityType.Name;

            StringBuilder createTableSql = new StringBuilder();
            createTableSql.Append($"CREATE TABLE {tableName} (");

            PropertyInfo[] properties = entityType.GetProperties();
            List<string> columns = new List<string>();
            List<string> foreignKeys = new List<string>(); // Lista para armazenar as FK

            foreach (PropertyInfo property in properties)
            {
                // Ignorar propriedades não editáveis
                if (property.GetCustomAttribute<Editavel>()?.HabilitarEdicao == false)
                    continue;

                Type propertyType = property.PropertyType;
                string columnName = property.Name;
                string columnType = ObterTipoColuna(property);

                bool ehObrigatorio = true;

                // Verificar se é Chave Primária
                if (property.GetCustomAttribute<ChavePrimaria>() != null)
                {
                    bool semAutoIncremento = property.GetCustomAttribute<SemAutoIncrementoAttribute>() != null;

                    if (semAutoIncremento)
                        columns.Add($"{columnName} {columnType} PRIMARY KEY");
                    else
                        columns.Add($"{columnName} {columnType} PRIMARY KEY AUTOINCREMENT"); // IDENTITY (VALIDAR NECESSIDADE E INCLUIR NO MOMENTO EM QUE CRIA BASE DE DADOS)
                }
                else
                {
                    bool isRequired = property.GetCustomAttribute<Obrigatorio>() != null;
                    bool isUnique = property.GetCustomAttribute<UnicoAttribute>() != null;

                    string constraints = "";

                    if (isRequired)
                        constraints += "NOT NULL";

                    if (isUnique)
                    {
                        if (!string.IsNullOrWhiteSpace(constraints))
                            constraints += " ";
                        constraints += "UNIQUE";
                    }

                    columns.Add($"{columnName} {columnType} {constraints}".Trim());

                    ehObrigatorio = isRequired;
                }

                // Verificar se é uma Foreign Key
                var relacionamento = property.GetCustomAttribute<Relacionamento>();
                if (relacionamento != null)
                {
                    // Adicionar a definição da chave estrangeira com o nome da chave primária referenciada
                    string fk = ObterSintaxeForeignKey(columnName, relacionamento.Tabela, relacionamento.ChavePrimaria);

                    if (!ehObrigatorio)
                        fk += " ON DELETE SET NULL";

                    foreignKeys.Add(fk);
                }
            }

            // Adicionar as colunas ao SQL
            createTableSql.Append(string.Join(", ", columns));

            // Adicionar as Foreign Keys (se houver)
            if (foreignKeys.Any())
            {
                createTableSql.Append(", ");
                createTableSql.Append(string.Join(", ", foreignKeys));
            }

            createTableSql.Append(");");

            try
            {
                var ret = connection.Execute(createTableSql.ToString(), transaction: transaction);
                return (ret > 0);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao criar a tabela '{tableName}': {createTableSql}", ex);
            }
        }

        public static bool CriarTabelas(this IDbConnection connection, string query, IDbTransaction transaction = null)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("A query para criação das tabelas não pode ser nula ou vazia.");

            var resultado = connection.Execute(query, transaction: transaction);

            return resultado > 0;
        }

        public static int ExecutarQuery(this IDbConnection connection, string query, object parametros = null, IDbTransaction transaction = null)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("A query fornecida não pode ser nula ou vazia.");

            return connection.Execute(query, parametros, transaction);
        }

        private static PropertyInfo ObterChavePrimaria(Type entidade)
        {
            var chavePrimaria = entidade.GetProperties().Where(i => i.GetCustomAttribute<ChavePrimaria>() != null).FirstOrDefault();

            if (chavePrimaria == null)
                throw new InvalidOperationException($"A entidade {entidade.Name} não possui uma chave primária definida.");

            return chavePrimaria;
        }

        private static string ObterTipoColuna(PropertyInfo propriedade)
        {
            Type propertyType = Nullable.GetUnderlyingType(propriedade.PropertyType) ?? propriedade.PropertyType;

            string tipoColuna;

            switch (propertyType.Name.ToLower())
            {
                case "string":
                    tipoColuna = "TEXT";
                    break;
                case "int32": //int
                    tipoColuna = "INTEGER";
                    break;
                case "int64": //long
                    tipoColuna = "BIGINT";
                    break;
                case "decimal":
                    tipoColuna = "DECIMAL";
                    break;
                case "double":
                    tipoColuna = "DOUBLE";
                    break;
                case "float":
                    tipoColuna = "FLOAT";
                    break;
                case "datetime":
                    tipoColuna = "DATETIME";
                    break;
                case "boolean":
                    tipoColuna = "BOOLEAN";
                    break;
                case "int16": // short
                    tipoColuna = "SMALLINT";
                    break;
                default:
                    throw new ArgumentException($"Tipo de propriedade não suportado: {propriedade.PropertyType.Name}");
            }

            if (propertyType == typeof(bool))
            {
                tipoColuna = "INTEGER";
            }
            else if (propertyType == typeof(decimal))
            {
                tipoColuna = "REAL";
            }

            return tipoColuna;
        }
        private static string ObterSintaxeForeignKey(string columnName, string tabelaReferenciada, string chavePrimaria)
        {
            return $"FOREIGN KEY ({columnName}) REFERENCES {tabelaReferenciada}({chavePrimaria})";
        }
    }
}
