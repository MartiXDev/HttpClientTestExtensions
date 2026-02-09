using System.Collections.Generic;
using MartiX.HttpClientTestExtensions.SharedKernel;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Core.Entities;

public class City : BaseEntity<int>, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public string? CountryId { get; set; }
  public virtual Country? Country { get; set; }
}
