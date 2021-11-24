using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace TypeSearch.Tests.SQLite.Mocks
{
    class TestContext : DbContext
    {
        public string DatabasePath { get; private set; }

        public TestContext(DbContextOptions options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            this.DatabasePath = $"{path}{Path.DirectorySeparatorChar}TypeSearch_SQLite_UnitTests.db";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Case-insensitive collation
            modelBuilder.UseCollation("NOCASE");

            //modelBuilder.Entity<TestParentEntity>()
            //    .HasOne(i => i.Child)
            //    .WithOne()
            //    .HasForeignKey<TestChildEntity>(i => i.ParentId);

            //modelBuilder.Entity<TestParentEntity>()
            //    .HasMany(i => i.Children)
            //    .WithOne()
            //    .HasForeignKey(i => i.ParentId);

            //modelBuilder.Entity<TestChildEntity>()
            //    .HasOne(i => i.GrandChild)
            //    .WithOne()
            //    .HasForeignKey<TestGrandChildEntity>(i => i.ParentId);

            base.OnModelCreating(modelBuilder);
        }

        // The following configures EF to create a Sqlite database file in the special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={this.DatabasePath}");

        public DbSet<TestEntity> TestEntities { get; set; }

        //public DbSet<ReservedKeywordsTestEntity> ReservedKeywordsTestEntities { get; set; }

        //public DbSet<TestParentEntity> TestParentEntities { get; set; }

        //public DbSet<TestChildEntity> TestChildEntities { get; set; }

        //public DbSet<TestChildrenEntity> TestChildrenEntities { get; set; }

        //public DbSet<TestGrandChildEntity> TestGrandChildEntities { get; set; }
    }
}
