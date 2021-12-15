using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
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
            using (var context = this.GetTestContext())
            {
                var dataset = context.TestParentEntities.Include("Child");

                // Act
                var searchDefinition = new SearchDefinition<TestParentEntity>();
                searchDefinition.Filter.Where(i => i.Child.ChildId).IsEqualTo(5);
                var searchResults = new EFCoreSearcher<TestParentEntity>(dataset).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 2);
                Assert.True(searchResults.ResultSet[0].Child.ChildId == 5);
            }
        }

        [Fact]
        public void Search_Single_Navigation_Property_Two_Levels_Deep_Should_Succeed()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                var dataset = context.TestParentEntities
                    .Include("Child")
                    .Include("Child.GrandChild");

                // Act
                var searchDefinition = new SearchDefinition<TestParentEntity>();
                searchDefinition.Filter.Where(i => i.Child.GrandChild.GrandChildId).IsEqualTo(8);
                var searchResults = new EFCoreSearcher<TestParentEntity>(dataset).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 2);
                Assert.True(searchResults.ResultSet[0].Child.ChildId == 5);
                Assert.True(searchResults.ResultSet[0].Child.GrandChild.GrandChildId == 8);
            }
        }

        [Fact]
        public void Search_Single_Multi_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                var dataset = context.TestParentEntities.Include("Children");

                // Act
                var searchDefinition = new SearchDefinition<TestParentEntity>();
                searchDefinition.Filter.Where(i => i.Children).Property(i => i.ChildrenId).IsEqualTo(5);
                var searchResults = new EFCoreSearcher<TestParentEntity>(dataset).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 2);
                Assert.True(searchResults.ResultSet[0].Child.ChildId == 5);
            }
        }

        [Fact]
        public void Search_Range_Multi_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                var dataset = context.TestParentEntities.Include("Children");

                // Act
                var searchDefinition = new SearchDefinition<TestParentEntity>();
                searchDefinition.Filter.Where(i => i.Children).Property(i => i.ChildrenId).Between(5, 10);
                var searchResults = new EFCoreSearcher<TestParentEntity>(dataset).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 2);
                Assert.True(searchResults.ResultSet[0].Child.ChildId == 5);
                Assert.True(searchResults.ResultSet[1].ParentId == 3);
                Assert.True(searchResults.ResultSet[1].Child.ChildId == 6);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(NavigationalTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestParentEntities.Add(new TestParentEntity() { ParentId = 1, Title = "Parent 1" });
                db.TestParentEntities.Add(new TestParentEntity() { ParentId = 2, Title = "Parent 2" });
                db.TestParentEntities.Add(new TestParentEntity() { ParentId = 3, Title = "Parent 3" });
                db.SaveChanges();

                db.TestChildEntities.Add(new TestChildEntity() { ChildId = 4, ParentId = 1, Title = "Child 4" });
                db.TestChildEntities.Add(new TestChildEntity() { ChildId = 5, ParentId = 2, Title = "Child 5" });
                db.TestChildEntities.Add(new TestChildEntity() { ChildId = 6, ParentId = 3, Title = "Child 6" });
                db.SaveChanges();

                db.TestGrandChildEntities.Add(new TestGrandChildEntity() { GrandChildId = 7, ParentId = 4, Title = "Grand Child 7" });
                db.TestGrandChildEntities.Add(new TestGrandChildEntity() { GrandChildId = 8, ParentId = 5, Title = "Grand Child 8" });
                db.TestGrandChildEntities.Add(new TestGrandChildEntity() { GrandChildId = 9, ParentId = 6, Title = "Grand Child 9" });
                db.SaveChanges();
            }

            return db;
        }
    }
}
