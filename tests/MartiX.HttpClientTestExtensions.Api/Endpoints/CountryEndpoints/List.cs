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

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CountryEndpoints;

public class List : EndpointWithoutRequest<ListResponse<CountryDto>>
{
  private readonly AutoMapper.IMapper _mapper;
  private readonly IReadRepository<Country> _repository;

  public List(AutoMapper.IMapper mapper, IReadRepository<Country> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  public override void Configure()
  {
    Get(ListCountryRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken = default)
  {
    var spec = new CountriesOrderByNameSpec();
    var entities = await _repository.ListAsync(spec, cancellationToken);
    var responseData = _mapper.Map<List<CountryDto>>(entities);
    var response = new ListResponse<CountryDto>(responseData);

    await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
  }
}
