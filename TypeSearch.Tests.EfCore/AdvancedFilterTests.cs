using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TypeSearch.Tests.EfCore
{
    public class AdvancedFilterTests
    {
        [Fact]
        public void AdvancedFilter_PreFilter()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("AdvancedFilter_PreFilter")
                .Options;

            using (var context = new TestContext(options))
            {
                // 510 entities: 255 true and 255 false
                for (int i = 0; i < byte.MaxValue; i++)
                {
                    context.TestEntities.Add(new TestEntity()
                    {
                        ByteProperty = (byte)i,
                        BoolProperty = true
                    });
                }
                for (int i = 0; i < byte.MaxValue; i++)
                {
                    context.TestEntities.Add(new TestEntity()
                    {
                        ByteProperty = (byte)i,
                        BoolProperty = false
                    });
                }
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.PreFilter.Where(i => i.BoolProperty).IsTrue();
                var searchResults = new Searcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .Where(i => i.BoolProperty)
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count, searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void AdvancedFilter_PreFilter_And_Filter()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("AdvancedFilter_PreFilter_And_Filter")
                .Options;

            using (var context = new TestContext(options))
            {
                // 510 entities: 255 true and 255 false
                for (int i = 0; i < byte.MaxValue; i++)
                {
                    context.TestEntities.Add(new TestEntity()
                    {
                        ByteProperty = (byte)i,
                        BoolProperty = true
                    });
                }
                for (int i = 0; i < byte.MaxValue; i++)
                {
                    context.TestEntities.Add(new TestEntity()
                    {
                        ByteProperty = (byte)i,
                        BoolProperty = false
                    });
                }
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.PreFilter.Where(i => i.BoolProperty).IsTrue();
                searchDefinition.Filter.Where(i => i.ByteProperty).GreaterThan(100);
                var searchResults = new Searcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .Where(i => i.BoolProperty)
                    .Where(i => i.ByteProperty > 100)
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count, searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void AdvancedFilter_PreFilter_And_Filter_And_Sort()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("AdvancedFilter_PreFilter_And_Filter_And_Sort")
                .Options;

            using (var context = new TestContext(options))
            {
                // 510 entities: 255 true and 255 false
                for (int i = 0; i < byte.MaxValue; i++)
                {
                    context.TestEntities.Add(new TestEntity()
                    {
                        ByteProperty = (byte)i,
                        BoolProperty = true
                    });
                }
                for (int i = 0; i < byte.MaxValue; i++)
                {
                    context.TestEntities.Add(new TestEntity()
                    {
                        ByteProperty = (byte)i,
                        BoolProperty = false
                    });
                }
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.PreFilter.Where(i => i.BoolProperty).IsTrue();
                searchDefinition.Filter.Where(i => i.ByteProperty).GreaterThan(100);
                searchDefinition.Sort.DescendingBy(i => i.ByteProperty);
                var searchResults = new Searcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .Where(i => i.BoolProperty)
                    .Where(i => i.ByteProperty > 100)
                    .OrderByDescending(i => i.ByteProperty)
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count, searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count, searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].ByteProperty, searchResults.ResultSet[0].ByteProperty);
                Assert.Equal(expectedResults[expectedResults.Count - 1].ByteProperty, searchResults.ResultSet[searchResults.ResultSet.Count - 1].ByteProperty);
            }
        }

        [Fact]
        public void AdvancedFilter_PreFilter_And_Filter_And_Sort_And_Page()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("AdvancedFilter_PreFilter_And_Filter_And_Sort_And_Page")
                .Options;

            using (var context = new TestContext(options))
            {
                // 510 entities: 255 true and 255 false
                for (int i = 0; i < byte.MaxValue; i++)
                {
                    context.TestEntities.Add(new TestEntity()
                    {
                        ByteProperty = (byte)i,
                        BoolProperty = true
                    });
                }
                for (int i = 0; i < byte.MaxValue; i++)
                {
                    context.TestEntities.Add(new TestEntity()
                    {
                        ByteProperty = (byte)i,
                        BoolProperty = false
                    });
                }
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>(page: 1, recordsPerPage: 50);
                searchDefinition.PreFilter.Where(i => i.BoolProperty).IsTrue();
                searchDefinition.Filter.Where(i => i.ByteProperty).GreaterThan(100);
                searchDefinition.Sort.DescendingBy(i => i.ByteProperty);
                var searchResults = new Searcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var preFilteredResults = context.TestEntities
                    .Where(i => i.BoolProperty)
                    .ToList();
                var filteredResults = preFilteredResults
                    .Where(i => i.BoolProperty)
                    .Where(i => i.ByteProperty > 100)
                    .OrderByDescending(i => i.ByteProperty)
                    .ToList();
                var pagedResults = filteredResults
                    .Skip(50)
                    .Take(50)
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(filteredResults.Count, searchResults.FilteredRecordCount);
                Assert.Equal(pagedResults.Count, searchResults.ResultSet.Count);
                Assert.Equal(pagedResults[0].ByteProperty, searchResults.ResultSet[0].ByteProperty);
                Assert.Equal(pagedResults[pagedResults.Count - 1].ByteProperty, searchResults.ResultSet[searchResults.ResultSet.Count - 1].ByteProperty);
            }
        }

        [Fact]
        public void AdvancedFilter_Or_Filter()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("AdvancedFilter_Or_Filter")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = false,
                        ByteProperty = 123,
                        DateTimeProperty = new DateTime(2004, 4, 14),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 1,
                        StringProperty = "Awesome sauce"
                    });
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = true,
                        ByteProperty = 221,
                        DateTimeProperty = new DateTime(2008, 8, 18),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 1,
                        StringProperty = "Bond. James Bond."
                    });
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = false,
                        ByteProperty = 56,
                        DateTimeProperty = new DateTime(2002, 2, 12),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 1,
                        StringProperty = "Onomatopoeia"
                    });
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = true,
                        ByteProperty = 32,
                        DateTimeProperty = new DateTime(2006, 6, 16),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 2,
                        StringProperty = "Noon racecar sagas"
                    });

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.ByteProperty).LessThan(100)
                    .Or(i => i.StringProperty).Contains("Bond");
                var searchResults = new Searcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .Where(i => i.ByteProperty < 100 || i.StringProperty.Contains("Bond"))
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count, searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void AdvancedFilter_And_Filter()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("AdvancedFilter_And_Filter")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = false,
                        ByteProperty = 123,
                        DateTimeProperty = new DateTime(2004, 4, 14),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 1,
                        StringProperty = "Awesome sauce"
                    });
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = true,
                        ByteProperty = 221,
                        DateTimeProperty = new DateTime(2008, 8, 18),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 1,
                        StringProperty = "Bond. James Bond."
                    });
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = false,
                        ByteProperty = 56,
                        DateTimeProperty = new DateTime(2002, 2, 12),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 1,
                        StringProperty = "Onomatopoeia"
                    });
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = true,
                        ByteProperty = 32,
                        DateTimeProperty = new DateTime(2006, 6, 16),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 2,
                        StringProperty = "Noon racecar sagas"
                    });

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.ByteProperty).GreaterThan(100)
                    .And(i => i.BoolProperty).IsTrue();
                var searchResults = new Searcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .Where(i => i.ByteProperty > 100 && i.BoolProperty)
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count, searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void AdvancedFilter_Nested_Filter()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("AdvancedFilter_Nested_Filter")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = false,
                        ByteProperty = 123,
                        DateTimeProperty = new DateTime(2004, 4, 14),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 1,
                        StringProperty = "Awesome sauce"
                    });
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = true,
                        ByteProperty = 221,
                        DateTimeProperty = new DateTime(2008, 8, 18),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 1,
                        StringProperty = "Bond. James Bond."
                    });
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = false,
                        ByteProperty = 56,
                        DateTimeProperty = new DateTime(2002, 2, 12),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 1,
                        StringProperty = "Onomatopoeia"
                    });
                context.TestEntities.Add(
                    new TestEntity()
                    {
                        BoolProperty = true,
                        ByteProperty = 32,
                        DateTimeProperty = new DateTime(2006, 6, 16),
                        GuidProperty = Guid.NewGuid(),
                        IntProperty = 2,
                        StringProperty = "Noon racecar sagas"
                    });

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(new WhereCriteria<TestEntity>()
                        .Where(i => i.IntProperty).IsEqualTo(1)
                        .And(i => i.ByteProperty).IsEqualTo(221)
                    )
                    .Or(new WhereCriteria<TestEntity>()
                        .Where(i => i.IntProperty).IsEqualTo(1)
                        .And(i => i.ByteProperty).IsEqualTo(123)
                    );
                var searchResults = new Searcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .Where(i => (i.IntProperty == 1 && i.ByteProperty == 221) || (i.IntProperty == 1 && i.ByteProperty == 123))
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count, searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count, searchResults.FilteredRecordCount);
            }
        }
    }
}
