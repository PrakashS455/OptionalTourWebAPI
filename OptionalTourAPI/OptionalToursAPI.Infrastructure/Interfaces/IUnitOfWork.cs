using System.Data.Odbc;

namespace OptionalToursAPI.Infrastructure.Interfaces
{
	public interface IUnitOfWork
    {
        IDatabaseContext DataContext { get; }
        OdbcTransaction BeginTransaction();
        void Commit();
    }
}
