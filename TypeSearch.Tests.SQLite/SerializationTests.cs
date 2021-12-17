using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Newtonsoft.Json;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class SerializationTests
    {
        [Fact]
        public void Serialization_PreFilter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.PreFilter.Where(i => i.BoolProperty).IsTrue();

                var jsonString = JsonConvert.SerializeObject(searchDefinition);
                var jsonDefintion = JsonConvert.DeserializeObject<SearchDefinition<TestEntity>>(jsonString);

                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(jsonDefintion);

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
        public void Serialization_PreFilter_And_Filter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.PreFilter.Where(i => i.BoolProperty).IsTrue();
                searchDefinition.Filter.Where(i => i.ByteProperty).GreaterThan(100);

                var jsonString = JsonConvert.SerializeObject(searchDefinition);
                var jsonDefintion = JsonConvert.DeserializeObject<SearchDefinition<TestEntity>>(jsonString);

                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(jsonDefintion);

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
        public void Serialization_PreFilter_And_Filter_And_Sort()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.PreFilter.Where(i => i.BoolProperty).IsTrue();
                searchDefinition.Filter.Where(i => i.ByteProperty).GreaterThan(100);
                searchDefinition.Sort.DescendingBy(i => i.ByteProperty);

                var jsonString = JsonConvert.SerializeObject(searchDefinition);
                var jsonDefintion = JsonConvert.DeserializeObject<SearchDefinition<TestEntity>>(jsonString);

                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(jsonDefintion);

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
        public void Serialization_PreFilter_And_Filter_And_Sort_And_Page()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>(page: 1, recordsPerPage: 50);
                searchDefinition.PreFilter.Where(i => i.BoolProperty).IsTrue();
                searchDefinition.Filter.Where(i => i.ByteProperty).GreaterThan(100);
                searchDefinition.Sort.DescendingBy(i => i.ByteProperty);

                var jsonString = JsonConvert.SerializeObject(searchDefinition);
                var jsonDefintion = JsonConvert.DeserializeObject<SearchDefinition<TestEntity>>(jsonString);

                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(jsonDefintion);

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
        public void Serialization_Or_Filter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.ByteProperty).LessThan(100)
                    .Or(i => i.StringProperty).Contains("Bond");

                var jsonString = JsonConvert.SerializeObject(searchDefinition);
                var jsonDefintion = JsonConvert.DeserializeObject<SearchDefinition<TestEntity>>(jsonString);

                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(jsonDefintion);

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
        public void Serialization_And_Filter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.ByteProperty).GreaterThan(100)
                    .And(i => i.BoolProperty).IsTrue();

                var jsonString = JsonConvert.SerializeObject(searchDefinition);
                var jsonDefintion = JsonConvert.DeserializeObject<SearchDefinition<TestEntity>>(jsonString);

                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(jsonDefintion);

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
        public void Serialization_Nested_Filter()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(new FilterCriteria<TestEntity>()
                        .Where(i => i.IntProperty).IsEqualTo(1)
                        .And(i => i.ByteProperty).IsEqualTo(221)
                    )
                    .Or(new FilterCriteria<TestEntity>()
                        .Where(i => i.IntProperty).IsEqualTo(1)
                        .And(i => i.ByteProperty).IsEqualTo(123)
                    );

                var jsonString = JsonConvert.SerializeObject(searchDefinition);
                var jsonDefintion = JsonConvert.DeserializeObject<SearchDefinition<TestEntity>>(jsonString);

                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(jsonDefintion);

                var expectedResults = context.TestEntities
                    .Where(i => (i.IntProperty == 1 && i.ByteProperty == 221) || (i.IntProperty == 1 && i.ByteProperty == 123))
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count, searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count, searchResults.FilteredRecordCount);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(SerializationTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                int i = 0;
                byte b = 0;
                for (; i < 510; i++, b++)
                {
                    db.TestEntities.Add(new TestEntity()
                    {
                        ByteProperty = b,
                        IntProperty = i,
                        BoolProperty = (i % 2 == 0)
                    });
                }

                db.TestEntities.Add(new TestEntity()
                {
                    ByteProperty = b,
                    IntProperty = i,
                    BoolProperty = (i % 2 == 0),
                    StringProperty = "Bond. James Bond."
                });

                db.SaveChanges();
            }

            return db;
        }
    }
}
