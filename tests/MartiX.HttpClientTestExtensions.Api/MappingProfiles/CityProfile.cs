using AutoMapper;
using MartiX.HttpClientTestExtensions.Api.Dtos;
using MartiX.HttpClientTestExtensions.Api.Endpoints.CityEndpoints;
using MartiX.HttpClientTestExtensions.Core.Entities;

namespace MartiX.HttpClientTestExtensions.Api.MappingProfiles;

public class CityProfile : Profile
{
  public CityProfile()
  {
    CreateMap<City, CityDto>();
    CreateMap<CityDto, City>();
    CreateMap<AddCityRequest, City>();
    CreateMap<EditCityRequest, City>();
  }
}

