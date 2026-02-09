using System.ComponentModel.DataAnnotations;

namespace MartiX.HttpClientTestExtensions.Api.Endpoints.CountryEndpoints;

public class AddCountryRequest
{
  public const string Route = "/countries";

  [Required]
  public string Id { get; set; } = string.Empty;
  [Required]
  public string Name { get; set; } = string.Empty;
}
