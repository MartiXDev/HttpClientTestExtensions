using System.ComponentModel.DataAnnotations;

namespace MartiX.HttpClientTestExtensions.Api.Dtos;

public class CountryDto
{
  public string Id { get; set; } = string.Empty;
  [Required]
  public string Name { get; set; } = string.Empty;
}

