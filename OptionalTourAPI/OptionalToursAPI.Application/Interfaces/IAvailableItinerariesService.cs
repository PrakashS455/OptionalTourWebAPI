using OptionalToursAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptionalToursAPI.Application.Interfaces
{
    public interface IAvailableItinerariesService
    {
        Task<IEnumerable<AvailableItinerariesModel>> GetAllAvailableItinerariesAsync();
    }
}
