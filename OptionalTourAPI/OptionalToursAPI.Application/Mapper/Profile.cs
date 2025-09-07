using AutoMapper;
using OptionalToursAPI.Application.Models;
using OptionalToursAPI.Core.Entities;
using OptionalToursAPI.Application.Models;
using OptionalToursAPI.Core.Entities;

namespace OptionalToursAPI.Application.Mapper
{
	public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {
            CreateMap<AvailableShips, AvailableShipsModel>().ReverseMap();
            CreateMap<AvailableItineraries, AvailableItinerariesModel>().ReverseMap();
            CreateMap<AvailablePriceAdjustment, AvailablePriceAdjustmentModel>().ReverseMap();
        }
    }
}
