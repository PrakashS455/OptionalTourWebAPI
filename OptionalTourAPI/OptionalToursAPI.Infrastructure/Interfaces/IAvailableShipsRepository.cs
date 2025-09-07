using System.Collections.Generic;
using OptionalToursAPI.Core.Entities;
using System;
using System.Threading.Tasks;
using OptionalToursAPI.Core.Entities;

namespace OptionalToursAPI.Infrastructure.Interfaces
{
    public interface IAvailableShipsRepository
    {
        Task<IEnumerable<AvailableShips>> GetAllAvailableShipsAsync();
    }
}
