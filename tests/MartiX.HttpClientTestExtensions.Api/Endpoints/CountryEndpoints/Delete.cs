using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using MartiX.HttpClientTestExtensions.Api.Dtos;
using MartiX.HttpClientTestExtensions.Core.Entities;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CountryEndpoints;

public class Delete : Endpoint<DeleteCountryRequest, CountryDto>
{
  private readonly AutoMapper.IMapper _mapper;
  private readonly IRepository<Country> _repository;

  public Delete(AutoMapper.IMapper mapper, IRepository<Country> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  public override void Configure()
  {
    Delete(DeleteCountryRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteCountryRequest deleteCountryRequest, CancellationToken cancellationToken = default)
  {
    var entity = await _repository.GetByIdAsync(deleteCountryRequest.Id, cancellationToken);
    if (entity == null)
    {
      HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
      return;
    }
    await _repository.DeleteAsync(entity, cancellationToken);

    var response = _mapper.Map<CountryDto>(entity);

    await HttpContext.Response.WriteAsJsonAsync(response, cancellationToken);
  }
}
