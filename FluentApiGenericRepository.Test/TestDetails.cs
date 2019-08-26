using System;
using FluentApiGenericRepository.Implementation;

namespace FluentApiGenericRepository.Test
{
    public class TestDetails : Entity<Guid>
    {
        public string Type { get; set; }
        public SubSubEntity SubSubEntity { get; set; }
    }
}
