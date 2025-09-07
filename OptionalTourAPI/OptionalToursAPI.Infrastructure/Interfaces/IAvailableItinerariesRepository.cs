using OptionalToursAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptionalToursAPI.Infrastructure.Interfaces
{
    public interface IAvailableItinerariesRepository
    {
        Task<IEnumerable<AvailableItineraries>> GetAllAvailableItinerariesAsync();
    }
}
