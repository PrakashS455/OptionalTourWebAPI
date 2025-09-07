using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Collections.Generic;
using OptionalToursAPI.Infrastructure.Interfaces;
using OptionalToursAPI.Infrastructure.Context;
using OptionalToursAPI.Core.Entities;
using System.Threading.Tasks;
using System;
using OptionalToursAPI.Core.Entities;

namespace OptionalToursAPI.Infrastructure.Repositories
{
    public class AvailableShipsRepository : GenericRepository<AvailableShips>, IAvailableShipsRepository
    {
        public AvailableShipsRepository(IUnitOfWork unitOfWork, IDataBaseManager dataBaseManager) : base(unitOfWork, dataBaseManager) { }

        public async Task<IEnumerable<AvailableShips>> GetAllAvailableShipsAsync()
        {
            var commandText = "Select * from gctfiles.OTSHIPSTB";
            return await GetAllAsync(commandText);
        }

        
    }
}
