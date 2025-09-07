using System.Collections.Generic;
using OptionalToursAPI.Application.Models;
using OptionalToursAPI.Core.Entities;
using System.Threading.Tasks;
using System;
using OptionalToursAPI.Application.Models;

namespace OptionalToursAPI.Application.Interfaces
{
    public interface IAvailableShipsService
    {
        Task<IEnumerable<AvailableShipsModel>> GetAllAvailableShipsAsync();
    }
}

