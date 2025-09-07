using OptionalToursAPI.Core.Entities;
using OptionalToursAPI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;
using System.Threading.Tasks;

namespace OptionalToursAPI.Infrastructure.Context
{
	 public interface IDataBaseManager
    {
        OdbcCommand CreateCommand(OdbcConnection connection);
        Task<List<T>> ExecuteReaderAllAsync<T>(OdbcCommand command);
        Task<T> ExecuteReaderAsync<T>(OdbcCommand command);
        object ExecuteScalar(OdbcCommand command);
        Task<int> ExecuteNonQueryAsync(OdbcCommand command); 
    }
}
