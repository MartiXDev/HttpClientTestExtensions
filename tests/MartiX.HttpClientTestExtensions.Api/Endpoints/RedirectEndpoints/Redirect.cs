using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.ErrorEndpoints;

public class Redirect : EndpointWithoutRequest
{
  public override void Configure()
  {
    Verbs(Http.GET, Http.POST, Http.PUT, Http.PATCH, Http.DELETE);
    Routes("/redirect");
    AllowAnonymous();
  }

  public override Task HandleAsync(CancellationToken cancellationToken = default)
  {
    HttpContext.Response.Redirect("/redirected");
    return Task.CompletedTask;
  }
}
