﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;

namespace TypeSearch.Tests.EfCore
{
    public class GuidTests
    {
        [Fact]
        public void Guid_IsEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Guid_IsEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.GuidProperty).IsEqualTo(new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.GuidProperty == new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Guid_IsNotEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Guid_IsNotEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.GuidProperty).IsNotEqualTo(new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.GuidProperty != new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Guid_In_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Guid_In_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.GuidProperty).In(new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5"));
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new Guid?[] { new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") }.Contains(i.GuidProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Guid_NotIn_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Guid_NotIn_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                context.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.GuidProperty).NotIn(new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5"));
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new Guid?[] { new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") }.Contains(i.GuidProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
