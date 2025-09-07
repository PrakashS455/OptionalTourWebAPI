using AutoMapper;
using OptionalToursAPI.Application.Models;
using OptionalToursAPI.Api.Models;
using OptionalToursAPI.Core.Entities;

namespace OptionalToursAPI.Api.Mapper
{
	public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {
            CreateMap<AvailableShipsModel, AvailableShipsRequestModel>().ReverseMap();
            CreateMap<AvailableShipsModel, AvailableShipsResponseModel>().ReverseMap();
            CreateMap<AvailableItinerariesModel, AvailableItinerariesRequestModel>().ReverseMap();
            CreateMap<AvailableItinerariesModel, AvailableItinerariesResponseModel>().ReverseMap();
            CreateMap<AvailablePriceAdjustmentModel, AvailablePriceAdjustmentRequestModel>().ReverseMap();
            CreateMap<AvailablePriceAdjustmentModel, AvailablePriceAdjustmentResponseModel>().ReverseMap();
        }
    }
}
