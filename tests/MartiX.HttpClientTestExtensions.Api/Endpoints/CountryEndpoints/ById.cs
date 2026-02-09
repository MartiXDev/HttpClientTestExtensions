using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using MartiX.HttpClientTestExtensions.Api.Dtos;
using MartiX.HttpClientTestExtensions.Core.Entities;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CountryEndpoints;

public class ById : Endpoint<ByIdCountryRequest, CountryDto>
{
  private readonly AutoMapper.IMapper _mapper;
  private readonly IReadRepository<Country> _repository;

  public ById(AutoMapper.IMapper mapper, IReadRepository<Country> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  public override void Configure()
  {
    Get(ByIdCountryRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(ByIdCountryRequest countryRequest, CancellationToken cancellationToken = default)
  {
    var entity = await _repository.GetByIdAsync(countryRequest.Id, cancellationToken);
    var response = _mapper.Map<CountryDto>(entity);

    await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
  }
}
