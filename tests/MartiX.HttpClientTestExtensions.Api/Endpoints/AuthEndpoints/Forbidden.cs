using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.AuthEndpoints;

public class Forbidden : EndpointWithoutRequest
{
  public override void Configure()
  {
    Verbs(Http.GET, Http.DELETE);
    Routes("/forbid");
    AllowAnonymous();
  }

  public override Task HandleAsync(CancellationToken cancellationToken = default)
  {
    HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
    return Task.CompletedTask;
  }
}
