using AutoMapper;
using MartiX.HttpClientTestExtensions.Api.Dtos;
using MartiX.HttpClientTestExtensions.Api.Endpoints.CountryEndpoints;
using MartiX.HttpClientTestExtensions.Core.Entities;

namespace MartiX.HttpClientTestExtensions.Api.MappingProfiles;

public class CountryProfile : Profile
{
  public CountryProfile()
  {
    CreateMap<Country, CountryDto>();
    CreateMap<CountryDto, Country>();
    CreateMap<AddCountryRequest, Country>();
    CreateMap<EditCountryRequest, Country>();
  }
}

