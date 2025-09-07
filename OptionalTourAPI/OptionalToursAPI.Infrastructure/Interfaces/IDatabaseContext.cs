using System.Data.Odbc;

namespace OptionalToursAPI.Infrastructure.Interfaces
{
	public interface IDatabaseContext
    {
        OdbcConnection Connection { get; }
        void Dispose();
    }
}

