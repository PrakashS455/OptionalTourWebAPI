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
    public class AvailablePriceAdjustmentService : IAvailablePriceAdjustmentService
    {
        private readonly IAvailablePriceAdjustmentRepository _availablePriceAdjustmentRepository;
        private readonly IMapper _mapper;

        public AvailablePriceAdjustmentService(IAvailablePriceAdjustmentRepository availablePriceAdjustmentRepository, IMapper mapper)
        {
            _availablePriceAdjustmentRepository = availablePriceAdjustmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AvailablePriceAdjustmentModel>> GetAllAvailablePriceAdjustmentAsync()
        {
            var list = await _availablePriceAdjustmentRepository.GetAllAvailablePriceAdjustmentAsync();
            var mappedEntity = _mapper.Map<IEnumerable<AvailablePriceAdjustmentModel>>(list);
            return mappedEntity;
        }
    }
}
