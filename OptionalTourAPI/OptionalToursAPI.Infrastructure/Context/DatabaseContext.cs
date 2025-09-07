using OptionalToursAPI.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using OptionalToursAPI.Common.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace OptionalToursAPI.Infrastructure.Context
{
	public class DatabaseContext : IDatabaseContext
    {
        private readonly IOptions<ConnectionStrings> _connectionStrings;
        //private SqlConnection _connection;
        private OdbcConnection _connection;

        public DatabaseContext(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public OdbcConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new OdbcConnection(_connectionStrings.Value.TemplateDatabase);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            _connection.Close();
        }
    }
}
