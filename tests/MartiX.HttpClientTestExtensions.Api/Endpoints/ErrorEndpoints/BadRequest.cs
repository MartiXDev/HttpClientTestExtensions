using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.ErrorEndpoints;

public class BadRequest : EndpointWithoutRequest
{
  public override void Configure()
  {
    Verbs(Http.GET, Http.DELETE, Http.PUT, Http.PATCH, Http.POST);
    Routes("/badrequest");
    AllowAnonymous();
  }

  public override Task HandleAsync(CancellationToken cancellationToken = default)
  {
    HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
    return Task.CompletedTask;
  }
}
