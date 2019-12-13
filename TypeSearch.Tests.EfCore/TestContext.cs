using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace TypeSearch.Tests.EfCore
{
    class TestContext : DbContext
    {
        public TestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }

        public DbSet<ReservedKeywordsTestEntity> ReservedKeywordsTestEntities { get; set; }
    }
}
