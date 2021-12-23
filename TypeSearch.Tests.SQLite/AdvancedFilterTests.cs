using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class AdvancedFilterTests
    {
        [Fact]
        public void AdvancedFilter_PreFilter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.PreFilter.Where(i => i.ByteProperty).IsEqualTo(DC);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(6, searchResults.TotalRecordCount);
                Assert.Equal(6, searchResults.ResultSet.Count);
                Assert.Equal(6, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void AdvancedFilter_PreFilter_And_Filter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.PreFilter.Where(i => i.ByteProperty).IsEqualTo(DC);
                searchDefinition.Filter.Where(i => i.BoolProperty).IsEqualTo(HERO);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(6, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void AdvancedFilter_PreFilter_And_Filter_And_Sort()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.PreFilter.Where(i => i.ByteProperty).IsEqualTo(DC);
                searchDefinition.Filter.Where(i => i.BoolProperty).IsEqualTo(HERO);
                searchDefinition.Sort.DescendingBy(i => i.IntProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(6, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
                Assert.Equal(5, searchResults.ResultSet[0].IntProperty);
                Assert.Equal(3, searchResults.ResultSet[1].IntProperty);
                Assert.Equal(1, searchResults.ResultSet[2].IntProperty);
            }
        }

        [Fact]
        public void AdvancedFilter_PreFilter_And_Filter_And_Sort_And_Page()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>(page: 1, recordsPerPage: 1);
                searchDefinition.PreFilter.Where(i => i.ByteProperty).IsEqualTo(DC);
                searchDefinition.Filter.Where(i => i.BoolProperty).IsEqualTo(HERO);
                searchDefinition.Sort.DescendingBy(i => i.IntProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(6, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
                Assert.Equal(3, searchResults.ResultSet[0].IntProperty);
                Assert.Equal(1, searchResults.Page);
                Assert.Equal(1, searchResults.RecordsPerPage);
            }
        }

        [Fact]
        public void AdvancedFilter_Or_Filter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).LessThanOrEqualTo(3)
                    .Or(i => i.StringProperty).Contains("man"); // Iron Man is #7 and Black Manta is #6
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(12, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
                Assert.Equal(1, searchResults.ResultSet[0].IntProperty);
                Assert.Equal(2, searchResults.ResultSet[1].IntProperty);
                Assert.Equal(3, searchResults.ResultSet[2].IntProperty);
                Assert.Equal("Black Manta", searchResults.ResultSet[3].StringProperty);
                Assert.Equal("Iron Man", searchResults.ResultSet[4].StringProperty);
            }
        }

        [Fact]
        public void AdvancedFilter_And_Filter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).LessThanOrEqualTo(6)
                    .And(i => i.StringProperty).Contains("man"); // SuperMAN, BatMAN, Black MANta
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(12, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
                Assert.Equal("Superman", searchResults.ResultSet[0].StringProperty);
                Assert.Equal("Batman", searchResults.ResultSet[1].StringProperty);
                Assert.Equal("Black Manta", searchResults.ResultSet[2].StringProperty);
            }
        }

        [Fact]
        public void AdvancedFilter_Nested_Filter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(new FilterCriteria<TestEntity>()
                        .Where(i => i.ByteProperty).IsEqualTo(DC)
                        .And(i => i.BoolProperty).IsEqualTo(HERO)
                    )
                    .Or(new FilterCriteria<TestEntity>()
                        .Where(i => i.ByteProperty).IsEqualTo(MARVEL)
                        .And(i => i.BoolProperty).IsEqualTo(HERO)
                    );
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(12, searchResults.TotalRecordCount);
                Assert.Equal(6, searchResults.ResultSet.Count);
                Assert.Equal(6, searchResults.FilteredRecordCount);
                Assert.Equal("Superman", searchResults.ResultSet[0].StringProperty);
                Assert.Equal("Batman", searchResults.ResultSet[1].StringProperty);
                Assert.Equal("Green Lantern", searchResults.ResultSet[2].StringProperty);
                Assert.Equal("Iron Man", searchResults.ResultSet[3].StringProperty);
                Assert.Equal("Captain America", searchResults.ResultSet[4].StringProperty);
                Assert.Equal("Thor", searchResults.ResultSet[5].StringProperty);
            }
        }

        // "Tenant" IDs
        const byte DC = 1;
        const byte MARVEL = 2;

        // Measure of "Goodness"
        const bool HERO = true;
        const bool VILLAIN = false;

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(AdvancedFilterTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                // DC
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = HERO,
                    ByteProperty = DC,
                    IntProperty = 1,
                    StringProperty = "Superman"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = VILLAIN,
                    ByteProperty = DC,
                    IntProperty = 2,
                    StringProperty = "Lex Luther"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = HERO,
                    ByteProperty = DC,
                    IntProperty = 3,
                    StringProperty = "Batman"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = VILLAIN,
                    ByteProperty = DC,
                    IntProperty = 4,
                    StringProperty = "The Joker"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = HERO,
                    ByteProperty = DC,
                    IntProperty = 5,
                    StringProperty = "Green Lantern"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = VILLAIN,
                    ByteProperty = DC,
                    IntProperty = 6,
                    StringProperty = "Black Manta"
                });

                // Marvel
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = HERO,
                    ByteProperty = MARVEL,
                    IntProperty = 7,
                    StringProperty = "Iron Man"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = VILLAIN,
                    ByteProperty = MARVEL,
                    IntProperty = 8,
                    StringProperty = "Thanos"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = HERO,
                    ByteProperty = MARVEL,
                    IntProperty = 9,
                    StringProperty = "Captain America"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = VILLAIN,
                    ByteProperty = MARVEL,
                    IntProperty = 10,
                    StringProperty = "Green Goblin"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = HERO,
                    ByteProperty = MARVEL,
                    IntProperty = 11,
                    StringProperty = "Thor"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    BoolProperty = VILLAIN,
                    ByteProperty = MARVEL,
                    IntProperty = 12,
                    StringProperty = "Magneto"
                });

                db.SaveChanges();
            }

            return db;
        }
    }
}
