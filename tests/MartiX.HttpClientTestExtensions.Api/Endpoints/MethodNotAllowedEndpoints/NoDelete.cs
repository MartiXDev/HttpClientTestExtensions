using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.MethodNotAllowedEndpoints;

public class NoDelete : EndpointWithoutRequest
{
  public override void Configure()
  {
    Verbs(Http.GET, Http.PUT, Http.POST);
    Routes("/nodelete");
    AllowAnonymous();
  }

  public override Task HandleAsync(CancellationToken cancellationToken = default)
  {
    HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
    return Task.CompletedTask;
  }
}
