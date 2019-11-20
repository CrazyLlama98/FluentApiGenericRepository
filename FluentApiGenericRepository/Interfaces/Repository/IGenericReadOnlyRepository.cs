namespace FluentApiGenericRepository.Interfaces.Repository
{
    public interface IGenericReadOnlyRepository<T> : IFilterable<T>
        where T : class
    {
    }
}
