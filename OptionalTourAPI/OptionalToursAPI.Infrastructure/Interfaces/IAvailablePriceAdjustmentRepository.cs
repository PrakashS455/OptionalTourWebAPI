using OptionalToursAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptionalToursAPI.Infrastructure.Interfaces
{
    public interface IAvailablePriceAdjustmentRepository
    {
        Task<IEnumerable<AvailablePriceAdjustment>> GetAllAvailablePriceAdjustmentAsync();
    }
}
