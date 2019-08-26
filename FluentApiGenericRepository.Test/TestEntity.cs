using System;
using System.Collections.Generic;
using FluentApiGenericRepository.Implementation;

namespace FluentApiGenericRepository.Test
{
    public class TestEntity : Entity<Guid>
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public IEnumerable<SubEntity> SubEntities { get; set; }
        public TestDetails TestDetails { get; set; }
    }
}
