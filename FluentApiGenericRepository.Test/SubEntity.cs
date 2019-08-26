using System;
using FluentApiGenericRepository.Implementation;

namespace FluentApiGenericRepository.Test
{
    public class SubEntity : Entity<Guid>
    {
        public string Name { get; set; }

        public SubSubEntity SubSubEntity { get; set; }
    }
}
