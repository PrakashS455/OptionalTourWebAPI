using OptionalToursAPI.Application.Interfaces;
using OptionalToursAPI.Application.Models;
using OptionalToursAPI.Core.Entities;
using OptionalToursAPI.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AutoMapper;
using OptionalToursAPI.Application.Models;
using OptionalToursAPI.Core.Entities;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using OptionalToursAPI.Common.Configuration;

namespace OptionalToursAPI.Application.Services
{
    public class AvailableShipsService : IAvailableShipsService
    {
        private readonly IAvailableShipsRepository _availableShipsRepository;
        private readonly IMapper _mapper;

        public AvailableShipsService(IAvailableShipsRepository availableShipsRepository, IMapper mapper)
        {
            _availableShipsRepository = availableShipsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AvailableShipsModel>> GetAllAvailableShipsAsync()
        {
            var list = await _availableShipsRepository.GetAllAvailableShipsAsync();
            var mappedEntity = _mapper.Map<IEnumerable<AvailableShipsModel>>(list);
            return mappedEntity ;
        }

        
    }
}
