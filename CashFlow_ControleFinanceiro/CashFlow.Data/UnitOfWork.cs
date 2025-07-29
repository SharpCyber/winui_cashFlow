using CashFlow.Data.Provider;
using CashFlow.Domain.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        public UnitOfWork()
        {
            _connection = SqliteProvider.CriarConexao();
        }

        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;

        public void Begin()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                _transaction = _connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao iniciar a transação", ex);
            }
        }
        public void Commit()
        {
            _transaction?.Commit();
        }
        public void Rollback()
        {
            _transaction?.Rollback();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _connection?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
