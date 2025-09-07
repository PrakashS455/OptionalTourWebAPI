using OptionalToursAPI.Core.Entities;
using OptionalToursAPI.Infrastructure.Context;
using OptionalToursAPI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptionalToursAPI.Infrastructure.Repositories
{
    public class AvailableItinerariesRepository : GenericRepository<AvailableItineraries>, IAvailableItinerariesRepository
    {
        public AvailableItinerariesRepository(IUnitOfWork unitOfWork, IDataBaseManager dataBaseManager) : base(unitOfWork, dataBaseManager) { }

        public async Task<IEnumerable<AvailableItineraries>> GetAllAvailableItinerariesAsync()
        {
            var commandText = "Select * from gctfiles.OTITINIDTB";
            return await GetAllAsync(commandText);
        }
    }
}
