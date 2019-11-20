namespace FluentApiGenericRepository.Interfaces
{
    public interface IDeletable<in T>
        where T : class
    {
        void Delete(T entity);
    }
}
