namespace FluentApiGenericRepository.Interfaces.Repository
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IAddable<T>, IUpdateable<T>, IDeletable<T>
        where T : class, IEntity
    {
    }
}
