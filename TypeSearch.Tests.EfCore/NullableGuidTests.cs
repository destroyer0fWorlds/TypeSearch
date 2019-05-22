using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TypeSearch.Tests.EfCore
{
    public class NullableGuidTests
    {
        [Fact]
        public void NullableGuid_IsEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_IsEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).IsEqualTo(null);
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableGuidProperty == null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_IsNotEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_IsNotEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).IsNotEqualTo(null);
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableGuidProperty != null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_In_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_In_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).In(new Guid?[] { null });
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new Guid?[] { null }.Contains(i.NullableGuidProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_NotIn_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_NotIn_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).NotIn(new Guid?[] { null });
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new Guid?[] { null }.Contains(i.NullableGuidProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_IsNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_IsNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).IsNull();
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableGuidProperty == null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_IsNotNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_IsNotNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).IsNotNull();
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableGuidProperty != null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_IsEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_IsEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).IsEqualTo(new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableGuidProperty == new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_IsNotEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_IsNotEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).IsNotEqualTo(new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableGuidProperty != new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_In_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_In_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).In(new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5"));
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new Guid?[] { new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") }.Contains(i.NullableGuidProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_NotIn_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableGuid_NotIn_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).NotIn(new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5"));
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new Guid?[] { new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") }.Contains(i.NullableGuidProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
