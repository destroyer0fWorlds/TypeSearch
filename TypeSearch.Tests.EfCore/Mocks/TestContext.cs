using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace TypeSearch.Tests.EfCore.Mocks
{
    class TestContext : DbContext
    {
        public TestContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestParentEntity>()
                .HasOne(i => i.Child)
                .WithOne()
                .HasForeignKey<TestChildEntity>(i => i.ParentId);

            modelBuilder.Entity<TestParentEntity>()
                .HasMany(i => i.Children)
                .WithOne()
                .HasForeignKey(i => i.ParentId);

            modelBuilder.Entity<TestChildEntity>()
                .HasOne(i => i.GrandChild)
                .WithOne()
                .HasForeignKey<TestGrandChildEntity>(i => i.ParentId);
        }

        public DbSet<TestEntity> TestEntities { get; set; }

        public DbSet<ReservedKeywordsTestEntity> ReservedKeywordsTestEntities { get; set; }

        public DbSet<TestParentEntity> TestParentEntities { get; set; }

        public DbSet<TestChildEntity> TestChildEntities { get; set; }

        public DbSet<TestChildrenEntity> TestChildrenEntities { get; set; }

        public DbSet<TestGrandChildEntity> TestGrandChildEntities { get; set; }
    }
}
