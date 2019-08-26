using System;
using System.Linq.Expressions;

namespace FluentApiGenericRepository.Interfaces.Queries
{
    public interface IJoinQuery<TMainEntity, TSubEntity> : IQuery<TMainEntity>
        where TMainEntity : class 
        where TSubEntity : class
    {
        IJoinQuery<TMainEntity, TProperty> ThenInclude<TProperty>(Expression<Func<TSubEntity, TProperty>> property)
            where TProperty : class;
    }
}
