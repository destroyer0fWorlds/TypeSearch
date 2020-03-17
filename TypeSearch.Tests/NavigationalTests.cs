using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;

namespace TypeSearch.Tests
{
    public class NavigationalTests
    {
        [Fact]
        public void Search_Single_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    Id = 1,
                    Title = "Parent 1",
                    Child = new TestChildEntity()
                    {
                        Id = 4,
                        Title = "Child 4"
                    }
                },
                new TestParentEntity()
                {
                    Id = 2,
                    Title = "Parent 2",
                    Child = new TestChildEntity()
                    {
                        Id = 5,
                        Title = "Child 5"
                    }
                },
                new TestParentEntity()
                {
                    Id = 3,
                    Title = "Parent 3",
                    Child = new TestChildEntity()
                    {
                        Id = 6,
                        Title = "Child 6"
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                .Where(i => i.Child.Id).IsEqualTo(5);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Child.Id == 5);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            Assert.True(searchResults.ResultSet[0].Id == 2);
            Assert.True(searchResults.ResultSet[0].Child.Id == 5);
        }

        [Fact]
        public void Search_Single_Navigation_Property_Two_Levels_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    Id = 1,
                    Title = "Parent 1",
                    Child = new TestChildEntity()
                    {
                        Id = 4,
                        Title = "Child 4",
                        NChild = new TestChildEntity()
                        {
                            Id = 7,
                            Title = "Child 7"
                        }
                    }
                },
                new TestParentEntity()
                {
                    Id = 2,
                    Title = "Parent 2",
                    Child = new TestChildEntity()
                    {
                        Id = 5,
                        Title = "Child 5",
                        NChild = new TestChildEntity()
                        {
                            Id = 8,
                            Title = "Child 8"
                        }
                    }
                },
                new TestParentEntity()
                {
                    Id = 3,
                    Title = "Parent 3",
                    Child = new TestChildEntity()
                    {
                        Id = 6,
                        Title = "Child 6",
                        NChild = new TestChildEntity()
                        {
                            Id = 9,
                            Title = "Child 9"
                        }
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                .Where(i => i.Child.NChild.Id).IsEqualTo(8);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Child.NChild.Id == 8);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            Assert.True(searchResults.ResultSet[0].Id == 2);
            Assert.True(searchResults.ResultSet[0].Child.Id == 5);
            Assert.True(searchResults.ResultSet[0].Child.NChild.Id == 8);
        }

        [Fact]
        public void Search_Single_Navigation_Property_N_Levels_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    Id = 1,
                    Title = "Parent 1",
                    Child = new TestChildEntity()
                    {
                        Id = 2,
                        Title = "Child 2",
                        NChild = new TestChildEntity()
                        {
                            Id = 3,
                            Title = "Child 3",
                            NChild = new TestChildEntity()
                            {
                                Id = 4,
                                Title = "Child 4",
                                NChild = new TestChildEntity()
                                {
                                    Id = 5,
                                    Title = "Child 5",
                                    NChild = new TestChildEntity()
                                    {
                                        Id = 6,
                                        Title = "Child 6"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                .Where(i => i.Child.NChild.NChild.NChild.NChild.Id).IsEqualTo(6);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Child.NChild.NChild.NChild.NChild.Id == 6);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            Assert.True(searchResults.ResultSet[0].Id == 1);
            Assert.True(searchResults.ResultSet[0].Child.Id == 2);
            Assert.True(searchResults.ResultSet[0].Child.NChild.Id == 3);
            Assert.True(searchResults.ResultSet[0].Child.NChild.NChild.Id == 4);
            Assert.True(searchResults.ResultSet[0].Child.NChild.NChild.NChild.Id == 5);
            Assert.True(searchResults.ResultSet[0].Child.NChild.NChild.NChild.NChild.Id == 6);
        }

        [Fact]
        public void Search_Multi_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    Id = 1,
                    Title = "Parent 1",
                    Children = new List<TestChildEntity>() {
                        new TestChildEntity()
                        {
                            Id = 4,
                            Title = "Child 4"
                        }
                    }
                },
                new TestParentEntity()
                {
                    Id = 2,
                    Title = "Parent 2",
                    Children = new List<TestChildEntity>() {
                        new TestChildEntity()
                        {
                            Id = 5,
                            Title = "Child 5"
                        },
                        new TestChildEntity()
                        {
                            Id = 6,
                            Title = "Child 6"
                        }
                    }
                },
                new TestParentEntity()
                {
                    Id = 3,
                    Title = "Parent 3",
                    Children = new List<TestChildEntity>() {
                        new TestChildEntity()
                        {
                            Id = 7,
                            Title = "Child 7"
                        },
                        new TestChildEntity()
                        {
                            Id = 8,
                            Title = "Child 8"
                        },
                        new TestChildEntity()
                        {
                            Id = 9,
                            Title = "Child 9"
                        }
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                // Children.Any(Id == 5);
                .Where(i => i.Children).Property(i => i.Id).IsEqualTo(5);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Children.Any(x => x.Id == 5));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }
    }
}
