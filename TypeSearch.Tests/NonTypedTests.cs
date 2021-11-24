using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using System.Linq.Dynamic.Core.Exceptions;
using TypeSearch.Tests.Mocks;
using TypeSearch.Providers.Collection;

namespace TypeSearch.Tests
{
    public class NonTypedTests
    {
        [Fact]
        public void NonTypedTests_Multiple_Criteria_Per_Condition_Should_Error()
        {
            // Arrange
            var testCollection = new List<TestEntity>();
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter.Criteria.Add(new Criteria.CriteriaContainer<TestEntity>()
            {
                SingleCriterion = new Criteria.SingleCriterion<TestEntity>(),
                RangeCriterion = new Criteria.RangeCriterion()
            });

            // Act
            Action action = () => {
                var searcher = new CollectionSearcher<TestEntity>(testCollection.AsQueryable());
                var searchResults = searcher.Search(searchDefinition);
            };

            // Assert
            Assert.Throws<NotSupportedException>(action);
        }

        [Fact]
        public void NonTypedTests_Unknown_Property_Name_Should_Error()
        {
            // Arrange
            var testCollection = new List<TestEntity>();
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter.Criteria.Add(new Criteria.CriteriaContainer<TestEntity>()
            {
                SingleCriterion = new Criteria.SingleCriterion<TestEntity>()
                {
                     Name = "Meh"
                }
            });

            // Act
            Action action = () => {
                var searcher = new CollectionSearcher<TestEntity>(testCollection.AsQueryable());
                var searchResults = searcher.Search(searchDefinition);
            };

            // Assert
            Assert.Throws<ParseException>(action);
        }

        [Fact]
        public void NonTypedTests_Missing_Property_Name_Should_Error()
        {
            // Arrange
            var testCollection = new List<TestEntity>();
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter.Criteria.Add(new Criteria.CriteriaContainer<TestEntity>()
            {
                SingleCriterion = new Criteria.SingleCriterion<TestEntity>()
            });

            // Act
            Action action = () => {
                var searcher = new CollectionSearcher<TestEntity>(testCollection.AsQueryable());
                var searchResults = searcher.Search(searchDefinition);
            };

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
