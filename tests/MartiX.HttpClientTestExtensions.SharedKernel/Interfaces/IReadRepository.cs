using System.Threading;
using System.Threading.Tasks;
using MartiX.Specification;

namespace MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
