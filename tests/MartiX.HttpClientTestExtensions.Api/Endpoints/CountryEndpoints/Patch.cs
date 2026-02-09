using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using MartiX.HttpClientTestExtensions.Api.Dtos;
using MartiX.HttpClientTestExtensions.Core.Entities;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CountryEndpoints;

public class Patch : Endpoint<EditCountryRequest, CountryDto>
{
  private readonly AutoMapper.IMapper _mapper;
  private readonly IReadRepository<Country> _readRepository;
  private readonly IRepository<Country> _repository;

  public Patch(AutoMapper.IMapper mapper, IReadRepository<Country> readRepository, IRepository<Country> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  public override void Configure()
  {
    Patch(EditCountryRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(EditCountryRequest countryDto, CancellationToken cancellationToken = default)
  {
    var entity = await _repository.GetByIdAsync(countryDto.Id, cancellationToken);
    if (entity == null)
    {
      HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
      return;
    }
    var entityToSave = _mapper.Map(countryDto, entity);
    await _repository.UpdateAsync(entityToSave, cancellationToken);

    var response = _mapper.Map<CountryDto>(entityToSave);

    await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
  }
}
