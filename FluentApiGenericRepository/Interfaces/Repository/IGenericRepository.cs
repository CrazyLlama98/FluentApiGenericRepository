namespace FluentApiGenericRepository.Interfaces.Repository
{
    public interface IGenericRepository<T> : IGenericReadOnlyRepository<T>, IAddable<T>, IUpdateable<T>, IDeletable<T>
        where T : class
    {
    }
}
