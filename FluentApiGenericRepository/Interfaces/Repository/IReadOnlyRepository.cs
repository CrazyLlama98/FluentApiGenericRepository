namespace FluentApiGenericRepository.Interfaces.Repository
{
    public interface IReadOnlyRepository<T> : IFilterable<T>
        where T : class, IEntity
    {
    }
}
