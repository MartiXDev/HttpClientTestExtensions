using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using MartiX.HttpClientTestExtensions.Api.Dtos;
using MartiX.HttpClientTestExtensions.Core.Entities;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CityEndpoints;

public class ById : Endpoint<ByIdCityRequest, CityDto>
{
  private readonly AutoMapper.IMapper _mapper;
  private readonly IReadRepository<City> _repository;

  public ById(AutoMapper.IMapper mapper, IReadRepository<City> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  public override void Configure()
  {
    Get(ByIdCityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(ByIdCityRequest cityRequest, CancellationToken cancellationToken = default)
  {
    var entity = await _repository.GetByIdAsync(cityRequest.Id, cancellationToken);
    var response = _mapper.Map<CityDto>(entity);

    await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
  }
}
