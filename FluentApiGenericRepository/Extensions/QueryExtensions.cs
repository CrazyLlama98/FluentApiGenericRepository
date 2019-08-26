using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentApiGenericRepository.Implementation.Queries;
using FluentApiGenericRepository.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FluentApiGenericRepository.Extensions
{
    public static class QueryExtensions
    {
        public static IJoinQuery<TMainEntity, TProperty> ThenInclude<TMainEntity, TSubEntity, TProperty>(
            this IJoinQuery<TMainEntity, IEnumerable<TSubEntity>> query,
            Expression<Func<TSubEntity, TProperty>> property) 
            where TMainEntity : class
            where TSubEntity : class
            where TProperty : class
        {
            var entities = (IIncludableQueryable<TMainEntity, IEnumerable<TSubEntity>>) query.Entities;

            return new JoinQuery<TMainEntity, TProperty>(entities.ThenInclude(property));
        }
    }
}
