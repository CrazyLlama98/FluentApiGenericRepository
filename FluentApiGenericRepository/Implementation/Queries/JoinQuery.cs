using System;
using System.Linq.Expressions;
using FluentApiGenericRepository.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FluentApiGenericRepository.Implementation.Queries
{
    public class JoinQuery<TMainEntity, TSubEntity> : Query<TMainEntity>, IJoinQuery<TMainEntity, TSubEntity> 
        where TMainEntity : class 
        where TSubEntity : class
    {
        public JoinQuery(IIncludableQueryable<TMainEntity, TSubEntity> entities) 
            : base(entities)
        {
        }

        public IJoinQuery<TMainEntity, TProperty> ThenInclude<TProperty>(
            Expression<Func<TSubEntity, TProperty>> property) 
            where TProperty : class
        {
            var entities = (IIncludableQueryable<TMainEntity, TSubEntity>) Entities;

            return new JoinQuery<TMainEntity, TProperty>(entities.ThenInclude(property));
        }
    }
}