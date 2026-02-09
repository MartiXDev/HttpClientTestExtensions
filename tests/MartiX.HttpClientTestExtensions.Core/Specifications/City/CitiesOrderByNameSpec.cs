using System.Linq;
using MartiX.Specification;
using MartiX.HttpClientTestExtensions.Core.Entities;

namespace MartiX.HttpClientTestExtensions.Core.Specifications;
public class CitiesOrderByNameSpec : Specification<City>
{
  public CitiesOrderByNameSpec()
  {
    Query
      .OrderBy(x => x.Name);
  }
}
