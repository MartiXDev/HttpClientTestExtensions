using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using MartiX.HttpClientTestExtensions.Core.Entities;
using MartiX.HttpClientTestExtensions.Core.Specifications;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CityEndpoints;

public class Delete : Endpoint<DeleteCityRequest, bool>
{
  private readonly IRepository<City> _repository;

  public Delete(IRepository<City> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Delete(DeleteCityRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteCityRequest deleteCityRequest, CancellationToken cancellationToken = default)
  {
    var entity = await _repository.GetByIdAsync(deleteCityRequest.Id, cancellationToken);
    if (entity == null)
    {
      HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
      return;
    }
    await _repository.DeleteAsync(entity, cancellationToken);

    await HttpContext.Response.WriteAsJsonAsync(true, cancellationToken);
  }
}
