using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using MartiX.HttpClientTestExtensions.Api.Dtos;
using MartiX.HttpClientTestExtensions.Core.Entities;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CityEndpoints;

public class Add : Endpoint<AddCityRequest, CityDto>
{
  private readonly AutoMapper.IMapper _mapper;
  private readonly IReadRepository<City> _readRepository;
  private readonly IRepository<City> _repository;

  public Add(AutoMapper.IMapper mapper, IReadRepository<City> readRepository, IRepository<City> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  public override void Configure()
  {
    Post(AddCityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(AddCityRequest cityDto, CancellationToken cancellationToken = default)
  {
    var entityToSave = _mapper.Map<City>(cityDto);

    var addedEntity = await _repository.AddAsync(entityToSave, cancellationToken);

    var response = _mapper.Map<CityDto>(addedEntity);

    await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
  }
}
