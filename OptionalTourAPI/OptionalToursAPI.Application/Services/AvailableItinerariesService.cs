using AutoMapper;
using OptionalToursAPI.Application.Interfaces;
using OptionalToursAPI.Application.Models;
using OptionalToursAPI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptionalToursAPI.Application.Services
{
    public class AvailableItinerariesService : IAvailableItinerariesService
    {
        private readonly IAvailableItinerariesRepository _availableItinerariesRepository;
        private readonly IMapper _mapper;

        public AvailableItinerariesService(IAvailableItinerariesRepository availableItinerariesRepository, IMapper mapper)
        {
            _availableItinerariesRepository = availableItinerariesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AvailableItinerariesModel>> GetAllAvailableItinerariesAsync()
        {
            var list = await _availableItinerariesRepository.GetAllAvailableItinerariesAsync();
            var mappedEntity = _mapper.Map<IEnumerable<AvailableItinerariesModel>>(list);
            return mappedEntity;
        }

    }
}
