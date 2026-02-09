using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using MartiX.HttpClientTestExtensions.Api.Dtos;
using MartiX.HttpClientTestExtensions.Core.Entities;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CountryEndpoints;

public class Add : Endpoint<AddCountryRequest, CountryDto>
{
  private readonly AutoMapper.IMapper _mapper;
  private readonly IReadRepository<Country> _readRepository;
  private readonly IRepository<Country> _repository;

  public Add(AutoMapper.IMapper mapper, IReadRepository<Country> readRepository, IRepository<Country> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  public override void Configure()
  {
    Post(AddCountryRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(AddCountryRequest countryDto, CancellationToken cancellationToken = default)
  {
    var entityToSave = _mapper.Map<Country>(countryDto);

    var addedEntity = await _repository.AddAsync(entityToSave, cancellationToken);

    var response = _mapper.Map<CountryDto>(addedEntity);

    await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
  }
}
