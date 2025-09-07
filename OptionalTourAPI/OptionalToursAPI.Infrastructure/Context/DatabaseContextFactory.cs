using OptionalToursAPI.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OptionalToursAPI.Common.Configuration;

namespace OptionalToursAPI.Infrastructure.Context
{
	public class DatabaseContextFactory : IDatabaseContextFactory
    {
        private IDatabaseContext _dataContext;
        private readonly IOptions<ConnectionStrings> _connectionStrings;

        public DatabaseContextFactory(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public IDatabaseContext Context()
        {
            if(_dataContext == null)
            {
                _dataContext = new DatabaseContext(_connectionStrings);
            }
            return _dataContext;
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
