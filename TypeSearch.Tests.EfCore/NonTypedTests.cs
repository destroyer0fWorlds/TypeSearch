using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq.Dynamic.Core.Exceptions;
using TypeSearch.Tests.EfCore.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.EfCore
{
    public class NonTypedTests
    {
        [Fact]
        public void NonTypedTests_Multiple_Criteria_Per_Condition_Should_Error()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NonTypedTests_Multiple_Criteria_Per_Condition_Should_Error")
                .Options;

            using (var context = new TestContext(options))
            {
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Criteria.Add(new Criteria.CriteriaContainer<TestEntity>()
                {
                    SingleCriterion = new Criteria.SingleCriterion<TestEntity>(),
                    RangeCriterion = new Criteria.RangeCriterion()
                });

                // Act
                Action action = () =>
                {
                    var searcher = new EFCoreSearcher<TestEntity>(context.TestEntities);
                    var searchResults = searcher.Search(searchDefinition);
                };

                // Assert
                Assert.Throws<NotSupportedException>(action);
            }
        }

        [Fact]
        public void NonTypedTests_Unknown_Property_Name_Should_Error()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NonTypedTests_Unknown_Property_Name_Should_Error")
                .Options;

            using (var context = new TestContext(options))
            {
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Criteria.Add(new Criteria.CriteriaContainer<TestEntity>()
                {
                    SingleCriterion = new Criteria.SingleCriterion<TestEntity>()
                    {
                        Name = "Meh"
                    }
                });

                // Act
                Action action = () =>
                {
                    var searcher = new EFCoreSearcher<TestEntity>(context.TestEntities);
                    var searchResults = searcher.Search(searchDefinition);
                };

                // Assert
                Assert.Throws<ParseException>(action);
            }
        }

        [Fact]
        public void NonTypedTests_Missing_Property_Name_Should_Error()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NonTypedTests_Missing_Property_Name_Should_Error")
                .Options;

            using (var context = new TestContext(options))
            {
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Criteria.Add(new Criteria.CriteriaContainer<TestEntity>()
                {
                    SingleCriterion = new Criteria.SingleCriterion<TestEntity>()
                });

                // Act
                Action action = () =>
                {
                    var searcher = new EFCoreSearcher<TestEntity>(context.TestEntities);
                    var searchResults = searcher.Search(searchDefinition);
                };

                // Assert
                Assert.Throws<ArgumentNullException>(action);
            }
        }
    }
}
