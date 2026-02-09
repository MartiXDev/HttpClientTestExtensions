using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.MethodNotAllowedEndpoints;

public class NoGet : EndpointWithoutRequest
{
  public override void Configure()
  {
    Verbs(Http.DELETE, Http.PUT, Http.POST);
    Routes("/noget");
    AllowAnonymous();
  }

  public override Task HandleAsync(CancellationToken cancellationToken = default)
  {
    HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
    return Task.CompletedTask;
  }
}
