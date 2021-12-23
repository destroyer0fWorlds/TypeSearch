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
                searchDefinition.Filter.Where(i => i.Child.ChildId).IsEqualTo(20);
                var searchResults = new EFCoreSearcher<TestParentEntity>(dataset).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 2);
                Assert.True(searchResults.ResultSet[0].Child.ChildId == 20);
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
                searchDefinition.Filter.Where(i => i.Child.GrandChild.GrandChildId).IsEqualTo(200);
                var searchResults = new EFCoreSearcher<TestParentEntity>(dataset).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 2);
                Assert.True(searchResults.ResultSet[0].Child.ChildId == 20);
                Assert.True(searchResults.ResultSet[0].Child.GrandChild.GrandChildId == 200);
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
                searchDefinition.Filter.Where(i => i.Children).Property(i => i.ChildrenId).IsEqualTo(22);
                var searchResults = new EFCoreSearcher<TestParentEntity>(dataset).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 1);
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
                searchDefinition.Filter.Where(i => i.Children).Property(i => i.ChildrenId).Between(20, 40);
                var searchResults = new EFCoreSearcher<TestParentEntity>(dataset).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
                Assert.True(searchResults.ResultSet[0].ParentId == 1);
                Assert.True(searchResults.ResultSet[1].ParentId == 2);
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
            var testEntity = db.TestParentEntities.FirstOrDefault();
            if (testEntity == null)
            {
                // Parents
                db.TestParentEntities.Add(new TestParentEntity() { ParentId = 1, Title = "Parent 1" });
                db.TestParentEntities.Add(new TestParentEntity() { ParentId = 2, Title = "Parent 2" });
                db.TestParentEntities.Add(new TestParentEntity() { ParentId = 3, Title = "Parent 3" });
                db.SaveChanges();

                // 1-1 Parent-Child
                db.TestChildEntities.Add(new TestChildEntity() { ChildId = 10, ParentId = 1, Title = "Child 10" });
                db.TestChildEntities.Add(new TestChildEntity() { ChildId = 20, ParentId = 2, Title = "Child 20" });
                db.TestChildEntities.Add(new TestChildEntity() { ChildId = 30, ParentId = 3, Title = "Child 30" });
                db.SaveChanges();

                // 1-N Parent-Children
                db.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 11, ParentId = 1, Title = "Child 11" });
                db.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 22, ParentId = 1, Title = "Child 22" });
                db.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 33, ParentId = 2, Title = "Child 33" });
                db.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 44, ParentId = 2, Title = "Child 44" });
                db.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 55, ParentId = 3, Title = "Child 55" });
                db.TestChildrenEntities.Add(new TestChildrenEntity() { ChildrenId = 66, ParentId = 3, Title = "Child 66" });
                db.SaveChanges();

                db.TestGrandChildEntities.Add(new TestGrandChildEntity() { GrandChildId = 100, ParentId = 10, Title = "Grand Child 100" });
                db.TestGrandChildEntities.Add(new TestGrandChildEntity() { GrandChildId = 200, ParentId = 20, Title = "Grand Child 200" });
                db.TestGrandChildEntities.Add(new TestGrandChildEntity() { GrandChildId = 300, ParentId = 30, Title = "Grand Child 300" });
                db.SaveChanges();
            }

            return db;
        }
    }
}
