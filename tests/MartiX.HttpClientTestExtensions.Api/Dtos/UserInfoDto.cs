using System.ComponentModel.DataAnnotations;

namespace MartiX.HttpClientTestExtensions.Api.Dtos;
public class UserInfoDto
{
  public int Id { get; set; }
  [Required]
  public string Address { get; set; } = string.Empty;
  [Required]
  public int CityId { get; set; }
}
