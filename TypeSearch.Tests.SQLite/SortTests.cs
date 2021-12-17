using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class SortTests
    {
        [Fact]
        public void Sort_Number_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.IntProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.IntProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].IntProperty, searchResults.ResultSet[0].IntProperty);
                Assert.Equal(expectedResults[1].IntProperty, searchResults.ResultSet[1].IntProperty);
                Assert.Equal(expectedResults[2].IntProperty, searchResults.ResultSet[2].IntProperty);
                Assert.Equal(expectedResults[3].IntProperty, searchResults.ResultSet[3].IntProperty);
            }
        }

        [Fact]
        public void Sort_Number_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.IntProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.IntProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].IntProperty, searchResults.ResultSet[0].IntProperty);
                Assert.Equal(expectedResults[1].IntProperty, searchResults.ResultSet[1].IntProperty);
                Assert.Equal(expectedResults[2].IntProperty, searchResults.ResultSet[2].IntProperty);
                Assert.Equal(expectedResults[3].IntProperty, searchResults.ResultSet[3].IntProperty);
            }
        }

        [Fact]
        public void Sort_DateTime_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.DateTimeProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.DateTimeProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].DateTimeProperty, searchResults.ResultSet[0].DateTimeProperty);
                Assert.Equal(expectedResults[1].DateTimeProperty, searchResults.ResultSet[1].DateTimeProperty);
                Assert.Equal(expectedResults[2].DateTimeProperty, searchResults.ResultSet[2].DateTimeProperty);
                Assert.Equal(expectedResults[3].DateTimeProperty, searchResults.ResultSet[3].DateTimeProperty);
            }
        }

        [Fact]
        public void Sort_DateTime_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.DateTimeProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.DateTimeProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].DateTimeProperty, searchResults.ResultSet[0].DateTimeProperty);
                Assert.Equal(expectedResults[1].DateTimeProperty, searchResults.ResultSet[1].DateTimeProperty);
                Assert.Equal(expectedResults[2].DateTimeProperty, searchResults.ResultSet[2].DateTimeProperty);
                Assert.Equal(expectedResults[3].DateTimeProperty, searchResults.ResultSet[3].DateTimeProperty);
            }
        }

        [Fact]
        public void Sort_Bool_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.BoolProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.BoolProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].BoolProperty, searchResults.ResultSet[0].BoolProperty);
                Assert.Equal(expectedResults[1].BoolProperty, searchResults.ResultSet[1].BoolProperty);
                Assert.Equal(expectedResults[2].BoolProperty, searchResults.ResultSet[2].BoolProperty);
                Assert.Equal(expectedResults[3].BoolProperty, searchResults.ResultSet[3].BoolProperty);
            }
        }

        [Fact]
        public void Sort_Bool_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.BoolProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.BoolProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].BoolProperty, searchResults.ResultSet[0].BoolProperty);
                Assert.Equal(expectedResults[1].BoolProperty, searchResults.ResultSet[1].BoolProperty);
                Assert.Equal(expectedResults[2].BoolProperty, searchResults.ResultSet[2].BoolProperty);
                Assert.Equal(expectedResults[3].BoolProperty, searchResults.ResultSet[3].BoolProperty);
            }
        }

        [Fact]
        public void Sort_String_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.StringProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.StringProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].StringProperty, searchResults.ResultSet[0].StringProperty);
                Assert.Equal(expectedResults[1].StringProperty, searchResults.ResultSet[1].StringProperty);
                Assert.Equal(expectedResults[2].StringProperty, searchResults.ResultSet[2].StringProperty);
                Assert.Equal(expectedResults[3].StringProperty, searchResults.ResultSet[3].StringProperty);
            }
        }

        [Fact]
        public void Sort_String_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.StringProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.StringProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].StringProperty, searchResults.ResultSet[0].StringProperty);
                Assert.Equal(expectedResults[1].StringProperty, searchResults.ResultSet[1].StringProperty);
                Assert.Equal(expectedResults[2].StringProperty, searchResults.ResultSet[2].StringProperty);
                Assert.Equal(expectedResults[3].StringProperty, searchResults.ResultSet[3].StringProperty);
            }
        }

        [Fact]
        public void Sort_Guid_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.GuidProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.GuidProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].GuidProperty, searchResults.ResultSet[0].GuidProperty);
                Assert.Equal(expectedResults[1].GuidProperty, searchResults.ResultSet[1].GuidProperty);
                Assert.Equal(expectedResults[2].GuidProperty, searchResults.ResultSet[2].GuidProperty);
                Assert.Equal(expectedResults[3].GuidProperty, searchResults.ResultSet[3].GuidProperty);
            }
        }

        [Fact]
        public void Sort_Guid_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.GuidProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.GuidProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].GuidProperty, searchResults.ResultSet[0].GuidProperty);
                Assert.Equal(expectedResults[1].GuidProperty, searchResults.ResultSet[1].GuidProperty);
                Assert.Equal(expectedResults[2].GuidProperty, searchResults.ResultSet[2].GuidProperty);
                Assert.Equal(expectedResults[3].GuidProperty, searchResults.ResultSet[3].GuidProperty);
            }
        }

        [Fact]
        public void Sort_NullableNumber_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.NullableIntProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.NullableIntProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableIntProperty, searchResults.ResultSet[0].NullableIntProperty);
                Assert.Equal(expectedResults[1].NullableIntProperty, searchResults.ResultSet[1].NullableIntProperty);
                Assert.Equal(expectedResults[2].NullableIntProperty, searchResults.ResultSet[2].NullableIntProperty);
                Assert.Equal(expectedResults[3].NullableIntProperty, searchResults.ResultSet[3].NullableIntProperty);
            }
        }

        [Fact]
        public void Sort_NullableNumber_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.NullableIntProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.NullableIntProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableIntProperty, searchResults.ResultSet[0].NullableIntProperty);
                Assert.Equal(expectedResults[1].NullableIntProperty, searchResults.ResultSet[1].NullableIntProperty);
                Assert.Equal(expectedResults[2].NullableIntProperty, searchResults.ResultSet[2].NullableIntProperty);
                Assert.Equal(expectedResults[3].NullableIntProperty, searchResults.ResultSet[3].NullableIntProperty);
            }
        }

        [Fact]
        public void Sort_NullableDateTime_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.NullableDateTimeProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.NullableDateTimeProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableDateTimeProperty, searchResults.ResultSet[0].NullableDateTimeProperty);
                Assert.Equal(expectedResults[1].NullableDateTimeProperty, searchResults.ResultSet[1].NullableDateTimeProperty);
                Assert.Equal(expectedResults[2].NullableDateTimeProperty, searchResults.ResultSet[2].NullableDateTimeProperty);
                Assert.Equal(expectedResults[3].NullableDateTimeProperty, searchResults.ResultSet[3].NullableDateTimeProperty);
            }
        }

        [Fact]
        public void Sort_NullableDateTime_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.NullableDateTimeProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.NullableDateTimeProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableDateTimeProperty, searchResults.ResultSet[0].NullableDateTimeProperty);
                Assert.Equal(expectedResults[1].NullableDateTimeProperty, searchResults.ResultSet[1].NullableDateTimeProperty);
                Assert.Equal(expectedResults[2].NullableDateTimeProperty, searchResults.ResultSet[2].NullableDateTimeProperty);
                Assert.Equal(expectedResults[3].NullableDateTimeProperty, searchResults.ResultSet[3].NullableDateTimeProperty);
            }
        }

        [Fact]
        public void Sort_NullableBool_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.NullableBoolProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.NullableBoolProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableBoolProperty, searchResults.ResultSet[0].NullableBoolProperty);
                Assert.Equal(expectedResults[1].NullableBoolProperty, searchResults.ResultSet[1].NullableBoolProperty);
                Assert.Equal(expectedResults[2].NullableBoolProperty, searchResults.ResultSet[2].NullableBoolProperty);
                Assert.Equal(expectedResults[3].NullableBoolProperty, searchResults.ResultSet[3].NullableBoolProperty);
            }
        }

        [Fact]
        public void Sort_NullableBool_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.NullableBoolProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.NullableBoolProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableBoolProperty, searchResults.ResultSet[0].NullableBoolProperty);
                Assert.Equal(expectedResults[1].NullableBoolProperty, searchResults.ResultSet[1].NullableBoolProperty);
                Assert.Equal(expectedResults[2].NullableBoolProperty, searchResults.ResultSet[2].NullableBoolProperty);
                Assert.Equal(expectedResults[3].NullableBoolProperty, searchResults.ResultSet[3].NullableBoolProperty);
            }
        }

        [Fact]
        public void Sort_NullableString_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.StringProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.StringProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].StringProperty, searchResults.ResultSet[0].StringProperty);
                Assert.Equal(expectedResults[1].StringProperty, searchResults.ResultSet[1].StringProperty);
                Assert.Equal(expectedResults[2].StringProperty, searchResults.ResultSet[2].StringProperty);
                Assert.Equal(expectedResults[3].StringProperty, searchResults.ResultSet[3].StringProperty);
            }
        }

        [Fact]
        public void Sort_NullableString_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.StringProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.StringProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].StringProperty, searchResults.ResultSet[0].StringProperty);
                Assert.Equal(expectedResults[1].StringProperty, searchResults.ResultSet[1].StringProperty);
                Assert.Equal(expectedResults[2].StringProperty, searchResults.ResultSet[2].StringProperty);
                Assert.Equal(expectedResults[3].StringProperty, searchResults.ResultSet[3].StringProperty);
            }
        }

        [Fact]
        public void Sort_NullableGuid_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.AscendingBy(i => i.NullableGuidProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderBy(i => i.NullableGuidProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableGuidProperty, searchResults.ResultSet[0].NullableGuidProperty);
                Assert.Equal(expectedResults[1].NullableGuidProperty, searchResults.ResultSet[1].NullableGuidProperty);
                Assert.Equal(expectedResults[2].NullableGuidProperty, searchResults.ResultSet[2].NullableGuidProperty);
                Assert.Equal(expectedResults[3].NullableGuidProperty, searchResults.ResultSet[3].NullableGuidProperty);
            }
        }

        [Fact]
        public void Sort_NullableGuid_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort.DescendingBy(i => i.NullableGuidProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.OrderByDescending(i => i.NullableGuidProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableGuidProperty, searchResults.ResultSet[0].NullableGuidProperty);
                Assert.Equal(expectedResults[1].NullableGuidProperty, searchResults.ResultSet[1].NullableGuidProperty);
                Assert.Equal(expectedResults[2].NullableGuidProperty, searchResults.ResultSet[2].NullableGuidProperty);
                Assert.Equal(expectedResults[3].NullableGuidProperty, searchResults.ResultSet[3].NullableGuidProperty);
            }
        }

        [Fact]
        public void Sort_Multiple_Fields_Asc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort
                    .AscendingBy(i => i.NullableByteProperty)
                    .AscendingBy(i => i.NullableIntProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .OrderBy(i => i.NullableByteProperty)
                    .ThenBy(i => i.NullableIntProperty)
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableByteProperty, searchResults.ResultSet[0].NullableByteProperty);
                Assert.Equal(expectedResults[1].NullableByteProperty, searchResults.ResultSet[1].NullableByteProperty);
                Assert.Equal(expectedResults[2].NullableByteProperty, searchResults.ResultSet[2].NullableByteProperty);
                Assert.Equal(expectedResults[3].NullableByteProperty, searchResults.ResultSet[3].NullableByteProperty);
                Assert.Equal(expectedResults[0].NullableIntProperty, searchResults.ResultSet[0].NullableIntProperty);
                Assert.Equal(expectedResults[1].NullableIntProperty, searchResults.ResultSet[1].NullableIntProperty);
                Assert.Equal(expectedResults[2].NullableIntProperty, searchResults.ResultSet[2].NullableIntProperty);
                Assert.Equal(expectedResults[3].NullableIntProperty, searchResults.ResultSet[3].NullableIntProperty);
            }
        }

        [Fact]
        public void Sort_Multiple_Fields_Desc()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort
                    .DescendingBy(i => i.NullableByteProperty)
                    .DescendingBy(i => i.NullableIntProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .OrderByDescending(i => i.NullableByteProperty)
                    .ThenByDescending(i => i.NullableIntProperty)
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableByteProperty, searchResults.ResultSet[0].NullableByteProperty);
                Assert.Equal(expectedResults[1].NullableByteProperty, searchResults.ResultSet[1].NullableByteProperty);
                Assert.Equal(expectedResults[2].NullableByteProperty, searchResults.ResultSet[2].NullableByteProperty);
                Assert.Equal(expectedResults[3].NullableByteProperty, searchResults.ResultSet[3].NullableByteProperty);
                Assert.Equal(expectedResults[0].NullableIntProperty, searchResults.ResultSet[0].NullableIntProperty);
                Assert.Equal(expectedResults[1].NullableIntProperty, searchResults.ResultSet[1].NullableIntProperty);
                Assert.Equal(expectedResults[2].NullableIntProperty, searchResults.ResultSet[2].NullableIntProperty);
                Assert.Equal(expectedResults[3].NullableIntProperty, searchResults.ResultSet[3].NullableIntProperty);
            }
        }

        [Fact]
        public void Sort_Multiple_Fields_In_Multiple_Directions()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Sort
                    .AscendingBy(i => i.NullableByteProperty)
                    .DescendingBy(i => i.NullableIntProperty);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .OrderBy(i => i.NullableByteProperty)
                    .ThenByDescending(i => i.NullableIntProperty)
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
                Assert.Equal(expectedResults[0].NullableByteProperty, searchResults.ResultSet[0].NullableByteProperty);
                Assert.Equal(expectedResults[1].NullableByteProperty, searchResults.ResultSet[1].NullableByteProperty);
                Assert.Equal(expectedResults[2].NullableByteProperty, searchResults.ResultSet[2].NullableByteProperty);
                Assert.Equal(expectedResults[3].NullableByteProperty, searchResults.ResultSet[3].NullableByteProperty);
                Assert.Equal(expectedResults[0].NullableIntProperty, searchResults.ResultSet[0].NullableIntProperty);
                Assert.Equal(expectedResults[1].NullableIntProperty, searchResults.ResultSet[1].NullableIntProperty);
                Assert.Equal(expectedResults[2].NullableIntProperty, searchResults.ResultSet[2].NullableIntProperty);
                Assert.Equal(expectedResults[3].NullableIntProperty, searchResults.ResultSet[3].NullableIntProperty);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(SortTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.Add(new TestEntity()
                {
                    NullableBoolProperty = null,
                    NullableByteProperty = null,
                    NullableDateTimeProperty = null,
                    NullableGuidProperty = null,
                    NullableIntProperty = null,
                    StringProperty = null
                });
                db.TestEntities.Add(new TestEntity()
                {
                    NullableBoolProperty = true,
                    NullableByteProperty = 221,
                    NullableDateTimeProperty = new DateTime(2008, 8, 18),
                    NullableGuidProperty = Guid.NewGuid(),
                    NullableIntProperty = 6485,
                    StringProperty = "Bond. James Bond."
                });
                db.TestEntities.Add(new TestEntity()
                {
                    NullableBoolProperty = false,
                    NullableByteProperty = 56,
                    NullableDateTimeProperty = new DateTime(2000, 4, 12),
                    NullableGuidProperty = Guid.NewGuid(),
                    NullableIntProperty = 159753,
                    StringProperty = "Onomatopoeia"
                });
                db.TestEntities.Add(new TestEntity()
                {
                    NullableBoolProperty = true,
                    NullableByteProperty = 56,
                    NullableDateTimeProperty = new DateTime(2004, 6, 15),
                    NullableGuidProperty = Guid.NewGuid(),
                    NullableIntProperty = 890,
                    StringProperty = "Keep it simple, stupid."
                });
                db.SaveChanges();
            }

            return db;
        }
    }
}
