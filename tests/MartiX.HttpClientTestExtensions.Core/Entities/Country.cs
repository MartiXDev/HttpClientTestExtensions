using System.Collections.Generic;
using MartiX.HttpClientTestExtensions.SharedKernel;
using MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

namespace MartiX.HttpClientTestExtensions.Core.Entities;

public class Country : BaseEntity<string>, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public virtual List<City> Cities { get; set; } = new List<City>();

  public void AddCity(City city)
  {
    Cities.Add(city);
  }
}

