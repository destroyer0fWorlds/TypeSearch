﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;

namespace TypeSearch.Tests.EfCore
{
    /*
     Notes on test naming and verbiage:
     - Single
        Refers to a specific operation format: [property][operation][value] i.e. FirstName = "John"
     - Range
        Refers to a specific operation formate: [property][operation][value1]and[value2] i.e. Age between 20 and 30
     - Navigation Property
        Refers to an entity which contains a reference to another entity i.e. User.Profile.Picture
     - Multi-Navigation Property
        Refers to an entity which contains a reference to a collection of entities i.e. User.Claims
     */
    public class NavigationalTests
    {
        [Fact]
        public void Search_Single_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 1, Title = "Parent 1" });
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 2, Title = "Parent 2" });
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 3, Title = "Parent 3" });
                context.SaveChanges();

                context.TestChildEntities.Add(new TestChildEntity() { ChildId = 4, ParentId = 1, Title = "Child 4" });
                context.TestChildEntities.Add(new TestChildEntity() { ChildId = 5, ParentId = 2, Title = "Child 5" });
                context.TestChildEntities.Add(new TestChildEntity() { ChildId = 6, ParentId = 3, Title = "Child 6" });
                context.SaveChanges();
            }

            using (var context = new TestContext(options))
            {
                var dataset = context.TestParentEntities
                    .Include("Child");

                // Act
                var searchDefinition = new SearchDefinition<TestParentEntity>();
                searchDefinition.Filter
                    .Where(i => i.Child.ChildId).IsEqualTo(5);
                var searchResults = new Searcher<TestParentEntity>(dataset)
                    .Search(searchDefinition);

                var expectedResults = dataset.Where(i => i.Child.ChildId == 5);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 2);
                Assert.True(searchResults.ResultSet[0].Child.ChildId == 5);
            }
        }

        [Fact]
        public void Search_Single_Navigation_Property_Two_Levels_Deep_Should_Succeed()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 1, Title = "Parent 1" });
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 2, Title = "Parent 2" });
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 3, Title = "Parent 3" });
                context.SaveChanges();

                context.TestChildEntities.Add(new TestChildEntity() { ChildId = 4, ParentId = 1, Title = "Child 4" });
                context.TestChildEntities.Add(new TestChildEntity() { ChildId = 5, ParentId = 2, Title = "Child 5" });
                context.TestChildEntities.Add(new TestChildEntity() { ChildId = 6, ParentId = 3, Title = "Child 6" });
                context.SaveChanges();

                context.TestGrandChildEntities.Add(new TestGrandChildEntity() { GrandChildId = 7, ParentId = 4, Title = "Grand Child 7" });
                context.TestGrandChildEntities.Add(new TestGrandChildEntity() { GrandChildId = 8, ParentId = 5, Title = "Grand Child 8" });
                context.TestGrandChildEntities.Add(new TestGrandChildEntity() { GrandChildId = 9, ParentId = 6, Title = "Grand Child 9" });
                context.SaveChanges();
            }

            using (var context = new TestContext(options))
            {
                var dataset = context.TestParentEntities
                    .Include("Child")
                    .Include("Child.GrandChild");

                // Act
                var searchDefinition = new SearchDefinition<TestParentEntity>();
                searchDefinition.Filter
                    .Where(i => i.Child.GrandChild.GrandChildId).IsEqualTo(8);
                var searchResults = new Searcher<TestParentEntity>(dataset)
                    .Search(searchDefinition);

                var expectedResults = dataset.Where(i => i.Child.GrandChild.GrandChildId == 8);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 2);
                Assert.True(searchResults.ResultSet[0].Child.ChildId == 5);
                Assert.True(searchResults.ResultSet[0].Child.GrandChild.GrandChildId == 8);
            }
        }

        [Fact]
        public void Search_Single_Multi_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 1, Title = "Parent 1" });
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 2, Title = "Parent 2" });
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 3, Title = "Parent 3" });
                context.SaveChanges();

                context.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 4, ParentId = 1, Title = "Child 4" });
                context.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 5, ParentId = 2, Title = "Child 5" });
                context.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 6, ParentId = 3, Title = "Child 6" });
                context.SaveChanges();
            }

            using (var context = new TestContext(options))
            {
                var dataset = context.TestParentEntities
                    .Include("Children");

                // Act
                var searchDefinition = new SearchDefinition<TestParentEntity>();
                searchDefinition.Filter
                    .Where(i => i.Children).Property(i => i.ChildrenId).IsEqualTo(5);
                var searchResults = new Searcher<TestParentEntity>(dataset)
                    .Search(searchDefinition);

                var expectedResults = dataset.Where(i => i.Children.Any(x => x.ChildrenId == 5));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Search_Range_Multi_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 1, Title = "Parent 1" });
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 2, Title = "Parent 2" });
                context.TestParentEntities.Add(new TestParentEntity() { ParentId = 3, Title = "Parent 3" });
                context.SaveChanges();

                context.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 4, ParentId = 1, Title = "Child 4" });
                context.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 5, ParentId = 2, Title = "Child 5" });
                context.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 6, ParentId = 3, Title = "Child 6" });
                context.SaveChanges();
            }

            using (var context = new TestContext(options))
            {
                var dataset = context.TestParentEntities
                    .Include("Children");

                // Act
                var searchDefinition = new SearchDefinition<TestParentEntity>();
                searchDefinition.Filter
                    .Where(i => i.Children).Property(i => i.ChildrenId).Between(5, 10);
                var searchResults = new Searcher<TestParentEntity>(dataset)
                    .Search(searchDefinition);

                var expectedResults = dataset.Where(i => i.Children.Any(x => x.ChildrenId >= 5 && x.ChildrenId <= 10));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
