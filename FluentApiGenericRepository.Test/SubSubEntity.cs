using System;
using FluentApiGenericRepository.Implementation;

namespace FluentApiGenericRepository.Test
{
    public class SubSubEntity : Entity<Guid>
    {
        public long Version { get; set; }
    }
}
