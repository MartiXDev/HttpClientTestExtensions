using System.Linq;
using MartiX.Specification;
using MartiX.HttpClientTestExtensions.Core.Entities;

namespace MartiX.HttpClientTestExtensions.Core.Specifications;
public class CountriesOrderByNameSpec : Specification<Country>
{
  public CountriesOrderByNameSpec()
  {
    Query
      .OrderBy(x => x.Name);
  }
}
