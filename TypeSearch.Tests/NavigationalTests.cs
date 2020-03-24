using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;

namespace TypeSearch.Tests
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
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    ParentId = 1,
                    Title = "Parent 1",
                    Child = new TestChildEntity()
                    {
                        ChildId = 4,
                        Title = "Child 4"
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 2,
                    Title = "Parent 2",
                    Child = new TestChildEntity()
                    {
                        ChildId = 5,
                        Title = "Child 5"
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 3,
                    Title = "Parent 3",
                    Child = new TestChildEntity()
                    {
                        ChildId = 6,
                        Title = "Child 6"
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                .Where(i => i.Child.ChildId).IsEqualTo(5);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Child.ChildId == 5);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            Assert.True(searchResults.ResultSet[0].ParentId == 2);
            Assert.True(searchResults.ResultSet[0].Child.ChildId == 5);
        }

        [Fact]
        public void Search_Single_Navigation_Property_Two_Levels_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    ParentId = 1,
                    Title = "Parent 1",
                    Child = new TestChildEntity()
                    {
                        ChildId = 4,
                        Title = "Child 4",
                        NChild = new TestChildEntity()
                        {
                            ChildId = 7,
                            Title = "Child 7"
                        }
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 2,
                    Title = "Parent 2",
                    Child = new TestChildEntity()
                    {
                        ChildId = 5,
                        Title = "Child 5",
                        NChild = new TestChildEntity()
                        {
                            ChildId = 8,
                            Title = "Child 8"
                        }
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 3,
                    Title = "Parent 3",
                    Child = new TestChildEntity()
                    {
                        ChildId = 6,
                        Title = "Child 6",
                        NChild = new TestChildEntity()
                        {
                            ChildId = 9,
                            Title = "Child 9"
                        }
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                .Where(i => i.Child.NChild.ChildId).IsEqualTo(8);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Child.NChild.ChildId == 8);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            Assert.True(searchResults.ResultSet[0].ParentId == 2);
            Assert.True(searchResults.ResultSet[0].Child.ChildId == 5);
            Assert.True(searchResults.ResultSet[0].Child.NChild.ChildId == 8);
        }

        [Fact]
        public void Search_Single_Navigation_Property_N_Levels_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    ParentId = 1,
                    Title = "Parent 1",
                    Child = new TestChildEntity()
                    {
                        ChildId = 2,
                        Title = "Child 2",
                        NChild = new TestChildEntity()
                        {
                            ChildId = 3,
                            Title = "Child 3",
                            NChild = new TestChildEntity()
                            {
                                ChildId = 4,
                                Title = "Child 4",
                                NChild = new TestChildEntity()
                                {
                                    ChildId = 5,
                                    Title = "Child 5",
                                    NChild = new TestChildEntity()
                                    {
                                        ChildId = 6,
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
                .Where(i => i.Child.NChild.NChild.NChild.NChild.ChildId).IsEqualTo(6);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Child.NChild.NChild.NChild.NChild.ChildId == 6);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            Assert.True(searchResults.ResultSet[0].ParentId == 1);
            Assert.True(searchResults.ResultSet[0].Child.ChildId == 2);
            Assert.True(searchResults.ResultSet[0].Child.NChild.ChildId == 3);
            Assert.True(searchResults.ResultSet[0].Child.NChild.NChild.ChildId == 4);
            Assert.True(searchResults.ResultSet[0].Child.NChild.NChild.NChild.ChildId == 5);
            Assert.True(searchResults.ResultSet[0].Child.NChild.NChild.NChild.NChild.ChildId == 6);
        }

        [Fact]
        public void Search_Range_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    ParentId = 1,
                    Title = "Parent 1",
                    Child = new TestChildEntity()
                    {
                        ChildId = 4,
                        Title = "Child 4"
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 2,
                    Title = "Parent 2",
                    Child = new TestChildEntity()
                    {
                        ChildId = 5,
                        Title = "Child 5"
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 3,
                    Title = "Parent 3",
                    Child = new TestChildEntity()
                    {
                        ChildId = 6,
                        Title = "Child 6"
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                .Where(i => i.Child.ChildId).Between(5, 10);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Child.ChildId >= 5 && i.Child.ChildId <= 10);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Search_Range_Navigation_Property_Two_Levels_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    ParentId = 1,
                    Title = "Parent 1",
                    Child = new TestChildEntity()
                    {
                        ChildId = 4,
                        Title = "Child 4",
                        NChild = new TestChildEntity()
                        {
                            ChildId = 7,
                            Title = "Child 7"
                        }
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 2,
                    Title = "Parent 2",
                    Child = new TestChildEntity()
                    {
                        ChildId = 5,
                        Title = "Child 5",
                        NChild = new TestChildEntity()
                        {
                            ChildId = 8,
                            Title = "Child 8"
                        }
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 3,
                    Title = "Parent 3",
                    Child = new TestChildEntity()
                    {
                        ChildId = 6,
                        Title = "Child 6",
                        NChild = new TestChildEntity()
                        {
                            ChildId = 9,
                            Title = "Child 9"
                        }
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                .Where(i => i.Child.NChild.ChildId).Between(8, 20);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Child.NChild.ChildId >= 8 && i.Child.NChild.ChildId <= 20);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Search_Range_Navigation_Property_N_Levels_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    ParentId = 1,
                    Title = "Parent 1",
                    Child = new TestChildEntity()
                    {
                        ChildId = 2,
                        Title = "Child 2",
                        NChild = new TestChildEntity()
                        {
                            ChildId = 3,
                            Title = "Child 3",
                            NChild = new TestChildEntity()
                            {
                                ChildId = 4,
                                Title = "Child 4",
                                NChild = new TestChildEntity()
                                {
                                    ChildId = 5,
                                    Title = "Child 5",
                                    NChild = new TestChildEntity()
                                    {
                                        ChildId = 6,
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
                .Where(i => i.Child.NChild.NChild.NChild.NChild.ChildId).Between(5, 7);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Child.NChild.NChild.NChild.NChild.ChildId >= 5 && i.Child.NChild.NChild.NChild.NChild.ChildId <= 7);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Search_Single_Multi_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    ParentId = 1,
                    Title = "Parent 1",
                    Children = new List<TestChildEntity>() {
                        new TestChildEntity()
                        {
                            ChildId = 4,
                            Title = "Child 4"
                        }
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 2,
                    Title = "Parent 2",
                    Children = new List<TestChildEntity>() {
                        new TestChildEntity()
                        {
                            ChildId = 5,
                            Title = "Child 5"
                        },
                        new TestChildEntity()
                        {
                            ChildId = 6,
                            Title = "Child 6"
                        }
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 3,
                    Title = "Parent 3",
                    Children = new List<TestChildEntity>() {
                        new TestChildEntity()
                        {
                            ChildId = 7,
                            Title = "Child 7"
                        },
                        new TestChildEntity()
                        {
                            ChildId = 8,
                            Title = "Child 8"
                        },
                        new TestChildEntity()
                        {
                            ChildId = 9,
                            Title = "Child 9"
                        }
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                .Where(i => i.Children).Property(i => i.ChildId).IsEqualTo(5);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Children.Any(x => x.ChildId == 5));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Search_Range_Multi_Navigation_Property_One_Level_Deep_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<TestParentEntity>()
            {
                new TestParentEntity()
                {
                    ParentId = 1,
                    Title = "Parent 1",
                    Children = new List<TestChildEntity>() {
                        new TestChildEntity()
                        {
                            ChildId = 4,
                            Title = "Child 4"
                        }
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 2,
                    Title = "Parent 2",
                    Children = new List<TestChildEntity>() {
                        new TestChildEntity()
                        {
                            ChildId = 5,
                            Title = "Child 5"
                        },
                        new TestChildEntity()
                        {
                            ChildId = 6,
                            Title = "Child 6"
                        }
                    }
                },
                new TestParentEntity()
                {
                    ParentId = 3,
                    Title = "Parent 3",
                    Children = new List<TestChildEntity>() {
                        new TestChildEntity()
                        {
                            ChildId = 7,
                            Title = "Child 7"
                        },
                        new TestChildEntity()
                        {
                            ChildId = 8,
                            Title = "Child 8"
                        },
                        new TestChildEntity()
                        {
                            ChildId = 9,
                            Title = "Child 9"
                        }
                    }
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestParentEntity>();
            searchDefinition.Filter
                .Where(i => i.Children).Property(i => i.ChildId).Between(5, 10);
            var searchResults = new Searcher<TestParentEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Children.Any(x => x.ChildId >= 5 && x.ChildId <= 10));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }
    }
}
