using System.Data.Odbc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using OptionalToursAPI.Core.Entities;
namespace OptionalToursAPI.Infrastructure.Interfaces
{
	public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string commandText, List<OdbcParameter> parameters = null);
        Task<T> GetByIdAsync(string commandText, List<OdbcParameter> parameters);
        Task<IEnumerable<Tx>> GetByQueryAllAsync<Tx>(string commandText, List<OdbcParameter> parameters);
        Task<Tx> GetByQueryAsync<Tx>(string commandText, List<OdbcParameter> parameters);
        long GetSingleId(string commandText, List<OdbcParameter> parameters);
        string GetSingleName(string commandText, List<OdbcParameter> parameters);
        int GetRowCount(string commandText, List<OdbcParameter> parameters);
        Task<int> InsertAsync(T entity, string commandText, OdbcTransaction sqlTransaction, List<OdbcParameter> parameters);
        Task<Tx> InsertAndGetIDAsync<Tx>(T entity, string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters);
        Task<int> UpdateAsync(string commandText, OdbcTransaction sqlTransaction, List<OdbcParameter> parameters);
        Task<int> DeleteAsync(string commandText, OdbcTransaction sqlTransaction, List<OdbcParameter> parameters);
        bool IsExist(string commandText, List<OdbcParameter> parameters);
    }
}
