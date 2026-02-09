namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CountryEndpoints;

public class ByIdCountryRequest
{
  public const string Route = "/countries/{id}";
  public static string BuildRoute(string id) => Route.Replace("{id}", id);
  public string Id { get; set; } = string.Empty;
}
