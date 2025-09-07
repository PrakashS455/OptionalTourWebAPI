using OptionalToursAPI.Core.Entities;
using OptionalToursAPI.Infrastructure.Context;
using OptionalToursAPI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptionalToursAPI.Infrastructure.Repositories
{
    public class AvailablePriceAdjustmentRepository : GenericRepository<AvailablePriceAdjustment>, IAvailablePriceAdjustmentRepository
    {
        public AvailablePriceAdjustmentRepository(IUnitOfWork unitOfWork, IDataBaseManager dataBaseManager) : base(unitOfWork, dataBaseManager) { }

        public async Task<IEnumerable<AvailablePriceAdjustment>> GetAllAvailablePriceAdjustmentAsync()
        {
            var commandText = "Select * from gctfiles.OTADJTYPTB";
            return await GetAllAsync(commandText);
        }
    }
}
