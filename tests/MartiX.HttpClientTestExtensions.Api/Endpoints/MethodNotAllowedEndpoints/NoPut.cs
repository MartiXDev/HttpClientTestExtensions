using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.ErrorEndpoints;

public class NoPut : EndpointWithoutRequest
{
  public override void Configure()
  {
    Verbs(Http.DELETE, Http.GET, Http.POST);
    Routes("/noput");
    AllowAnonymous();
  }

  public override Task HandleAsync(CancellationToken cancellationToken = default)
  {
    HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
    return Task.CompletedTask;
  }

}
