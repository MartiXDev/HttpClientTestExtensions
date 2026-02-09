using MartiX.Specification;

namespace MartiX.HttpClientTestExtensions.SharedKernel.Interfaces;

// from MartiX.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
