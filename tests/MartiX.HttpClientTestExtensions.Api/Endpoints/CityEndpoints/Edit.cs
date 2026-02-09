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

public class Edit : Endpoint<EditCityRequest, CityDto>
{
  private readonly AutoMapper.IMapper _mapper;
  private readonly IReadRepository<City> _readRepository;
  private readonly IRepository<City> _repository;

  public Edit(AutoMapper.IMapper mapper, IReadRepository<City> readRepository, IRepository<City> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  public override void Configure()
  {
    Put(EditCityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(EditCityRequest cityDto, CancellationToken cancellationToken = default)
  {
    var entity = await _repository.GetByIdAsync(cityDto.Id, cancellationToken);
    if (entity == null)
    {
      HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
      return;
    }
    var entityToSave = _mapper.Map<City>(cityDto);
    await _repository.UpdateAsync(entityToSave, cancellationToken);

    var response = _mapper.Map<CityDto>(entityToSave);

    await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
  }
}
