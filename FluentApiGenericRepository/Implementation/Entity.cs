using System;
using FluentApiGenericRepository.Interfaces;

namespace FluentApiGenericRepository.Implementation
{
    public class Entity<TKey> : IEntity
        where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }

        object IEntity.Id
        {
            get => Id;
            set => Id = (TKey)Convert.ChangeType(value, typeof(TKey));
        }
    }
}
