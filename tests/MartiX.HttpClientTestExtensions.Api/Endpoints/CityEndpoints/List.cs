using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using MartiX.HttpClientTestExtensions.Api.Dtos;
using MartiX.HttpClientTestExtensions.Core.Entities;
using MartiX.HttpClientTestExtensions.Core.Specifications;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CityEndpoints;

public class List : EndpointWithoutRequest<ListResponse<CityDto>>
{
  private readonly AutoMapper.IMapper _mapper;
  private readonly IReadRepository<City> _repository;

  public List(AutoMapper.IMapper mapper, IReadRepository<City> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  public override void Configure()
  {
    Get(ListCityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken = default)
  {
    var spec = new CitiesOrderByNameSpec();
    var entities = await _repository.ListAsync(spec, cancellationToken);
    var responseData = _mapper.Map<List<CityDto>>(entities);
    var response = new ListResponse<CityDto>(responseData);

    await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
  }
}
