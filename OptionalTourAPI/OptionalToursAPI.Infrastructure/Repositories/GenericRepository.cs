using OptionalToursAPI.Infrastructure.Interfaces;
using OptionalToursAPI.Infrastructure.Context;
using OptionalToursAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Threading.Tasks;
using System.Linq;

namespace OptionalToursAPI.Infrastructure.Interfaces
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly OdbcConnection _conn;
        protected readonly IUnitOfWork UnitOfWork;
        private readonly IDataBaseManager _dataBaseManager;

        protected GenericRepository(IUnitOfWork uow, IDataBaseManager dataBaseManager)
        {
            UnitOfWork = uow ?? throw new ArgumentNullException(nameof(IUnitOfWork));
            _conn = UnitOfWork.DataContext.Connection;
            _dataBaseManager = dataBaseManager;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string commandText, List<OdbcParameter> parameters = null)
        {
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                var items = await _dataBaseManager.ExecuteReaderAllAsync<T>(cmd);
                return items;
            }
        }

        public async Task<T> GetByIdAsync(string commandText, List<OdbcParameter> parameters)
        {
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                // cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(parameters.ToArray());
                return await _dataBaseManager.ExecuteReaderAsync<T>(cmd);
            }
        }

        public async Task<IEnumerable<Tx>> GetByQueryAllAsync<Tx>(string commandText, List<OdbcParameter> parameters)
        {
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                // cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(parameters.ToArray());
                return await _dataBaseManager.ExecuteReaderAllAsync<Tx>(cmd);
            }
        }

        public async Task<Tx> GetByQueryAsync<Tx>(string commandText, List<OdbcParameter> parameters)
        {
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                // cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(parameters.ToArray());
                return await _dataBaseManager.ExecuteReaderAsync<Tx>(cmd);
            }
        }

        public int GetRowCount(string commandText, List<OdbcParameter> parameters)
        {
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters.ToArray());
                return (int)_dataBaseManager.ExecuteScalar(cmd);
            }
        }

        public long GetSingleId(string commandText, List<OdbcParameter> parameters)
        {
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters.ToArray());
                return (long)_dataBaseManager.ExecuteScalar(cmd);
            }
        }

        public string GetSingleName(string commandText, List<OdbcParameter> parameters)
        {
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters.ToArray());
                return (string)_dataBaseManager.ExecuteScalar(cmd);
            }
        }

        public async Task<int> InsertAsync(T entity, string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters)
        {
            var i = 0;
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = OdbcTransaction;
                cmd.Parameters.AddRange(parameters.ToArray());
                i = await _dataBaseManager.ExecuteNonQueryAsync(cmd);
                return i;
            }
        }

        public async Task<Tx> InsertAndGetIDAsync<Tx>(T entity, string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters)
        {
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = OdbcTransaction;
                cmd.Parameters.AddRange(parameters.ToArray());
                return await _dataBaseManager.ExecuteReaderAsync<Tx>(cmd);
            }
        }

        public async Task<int> UpdateAsync(string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters)
        {
            var i = 0;
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = OdbcTransaction;
                cmd.Parameters.AddRange(parameters.ToArray());
                i = await _dataBaseManager.ExecuteNonQueryAsync(cmd);
            }
            return i;
        }

        public async Task<int> DeleteAsync(string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters)
        {
            var i = 0;
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = OdbcTransaction;
                cmd.Parameters.AddRange(parameters.ToArray());
                i = await _dataBaseManager.ExecuteNonQueryAsync(cmd);
            }
            return i;
        }

        public bool IsExist(string commandText, List<OdbcParameter> parameters)
        {
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters.ToArray());
                return (bool)_dataBaseManager.ExecuteScalar(cmd);
            }
        }

    }
	
}
