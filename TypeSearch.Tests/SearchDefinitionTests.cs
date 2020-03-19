using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;

namespace TypeSearch.Tests
{
    public class SearchDefinitionTests
    {
        [Fact]
        public void SearchDefinition_New_Definition()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 123,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 89234,
                    StringProperty = "Awesome sauce"
                },
                new TestEntity() {
                    BoolProperty = true,
                    ByteProperty = 221,
                    DateTimeProperty = new DateTime(2008, 8, 18),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 6485,
                    StringProperty = "Bond. James Bond."
                },
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 56,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 159753,
                    StringProperty = "Onomatopoeia"
                }
            };

            // Act
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(new SearchDefinition<TestEntity>());

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(testCollection.Count, searchResults.ResultSet.Count);
            Assert.Equal(testCollection.Count, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void SearchDefinition_Null_Definition()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 123,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 89234,
                    StringProperty = "Awesome sauce"
                },
                new TestEntity() {
                    BoolProperty = true,
                    ByteProperty = 221,
                    DateTimeProperty = new DateTime(2008, 8, 18),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 6485,
                    StringProperty = "Bond. James Bond."
                },
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 56,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 159753,
                    StringProperty = "Onomatopoeia"
                }
            };

            // Act
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(testCollection.Count, searchResults.ResultSet.Count);
            Assert.Equal(testCollection.Count, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void SearchDefinition_Empty_Criteria()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 123,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 89234,
                    StringProperty = "Awesome sauce"
                },
                new TestEntity() {
                    BoolProperty = true,
                    ByteProperty = 221,
                    DateTimeProperty = new DateTime(2008, 8, 18),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 6485,
                    StringProperty = "Bond. James Bond."
                },
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 56,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 159753,
                    StringProperty = "Onomatopoeia"
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>()
            {
                Filter = new FilterCriteria<TestEntity>(),
                PreFilter = new FilterCriteria<TestEntity>(),
                Sort = new SortCriteria<TestEntity>()
            };
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(testCollection.Count, searchResults.ResultSet.Count);
            Assert.Equal(testCollection.Count, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void SearchDefinition_Null_Criteria()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 123,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 89234,
                    StringProperty = "Awesome sauce"
                },
                new TestEntity() {
                    BoolProperty = true,
                    ByteProperty = 221,
                    DateTimeProperty = new DateTime(2008, 8, 18),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 6485,
                    StringProperty = "Bond. James Bond."
                },
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 56,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 159753,
                    StringProperty = "Onomatopoeia"
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>()
            {
                Filter = null,
                PreFilter = null,
                Sort = null
            };
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(testCollection.Count, searchResults.ResultSet.Count);
            Assert.Equal(testCollection.Count, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void SearchDefinition_Paging_No_Page_Specified()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 123,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 89234,
                    StringProperty = "Awesome sauce"
                },
                new TestEntity() {
                    BoolProperty = true,
                    ByteProperty = 221,
                    DateTimeProperty = new DateTime(2008, 8, 18),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 6485,
                    StringProperty = "Bond. James Bond."
                },
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 56,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 159753,
                    StringProperty = "Onomatopoeia"
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>() { RecordsPerPage = 1 };
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Null(searchResults.Page);
            Assert.Equal(1, searchResults.RecordsPerPage);
            Assert.Equal(testCollection.Count, searchResults.ResultSet.Count);
            Assert.Equal(testCollection.Count, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void SearchDefinition_Paging_No_RecordsPerPage_Specified()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 123,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 89234,
                    StringProperty = "Awesome sauce"
                },
                new TestEntity() {
                    BoolProperty = true,
                    ByteProperty = 221,
                    DateTimeProperty = new DateTime(2008, 8, 18),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 6485,
                    StringProperty = "Bond. James Bond."
                },
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 56,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 159753,
                    StringProperty = "Onomatopoeia"
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>() { Page = 1 };
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(1, searchResults.Page);
            Assert.Null(searchResults.RecordsPerPage);
            Assert.Equal(testCollection.Count, searchResults.ResultSet.Count);
            Assert.Equal(testCollection.Count, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void SearchDefinition_Paging_Page_And_RecordsPerPage_Too_High()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 123,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 89234,
                    StringProperty = "Awesome sauce"
                },
                new TestEntity() {
                    BoolProperty = true,
                    ByteProperty = 221,
                    DateTimeProperty = new DateTime(2008, 8, 18),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 6485,
                    StringProperty = "Bond. James Bond."
                },
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 56,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 159753,
                    StringProperty = "Onomatopoeia"
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>() { Page = 9, RecordsPerPage = 50 };
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(9, searchResults.Page);
            Assert.Equal(50, searchResults.RecordsPerPage);
            Assert.Empty(searchResults.ResultSet);
            Assert.Equal(testCollection.Count, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void SearchDefinition_Paging_Page_And_RecordsPerPage_Too_Low()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 123,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 89234,
                    StringProperty = "Awesome sauce"
                },
                new TestEntity() {
                    BoolProperty = true,
                    ByteProperty = 221,
                    DateTimeProperty = new DateTime(2008, 8, 18),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 6485,
                    StringProperty = "Bond. James Bond."
                },
                new TestEntity() {
                    BoolProperty = false,
                    ByteProperty = 56,
                    DateTimeProperty = new DateTime(2000, 4, 12),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 159753,
                    StringProperty = "Onomatopoeia"
                }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>() { Page = -7, RecordsPerPage = -49 };
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition);

            var expectedResults = testCollection
                .Skip(-7)
                .Take(-49)
                .ToList();

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(-7, searchResults.Page);
            Assert.Equal(-49, searchResults.RecordsPerPage);
            Assert.Equal(expectedResults.Count, searchResults.ResultSet.Count);
            Assert.Equal(testCollection.Count, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void SearchDefinition_Paging_Does_Not_Duplicate_Or_Skip_Any_Records()
        {
            // Arrange
            var testCollection = new List<TestEntity>();
            for (int i = 0; i < byte.MaxValue; i++)
            {
                testCollection.Add(new TestEntity());
            }

            // Act
            var searchDefinition1 = new SearchDefinition<TestEntity>() { Page = 0, RecordsPerPage = 50 }; // 0-50
            var searchDefinition2 = new SearchDefinition<TestEntity>() { Page = 1, RecordsPerPage = 50 }; // 51-100
            var searchDefinition3 = new SearchDefinition<TestEntity>() { Page = 2, RecordsPerPage = 50 }; // 101-150
            var searchDefinition4 = new SearchDefinition<TestEntity>() { Page = 3, RecordsPerPage = 50 }; // 151-200
            var searchDefinition5 = new SearchDefinition<TestEntity>() { Page = 4, RecordsPerPage = 50 }; // 201-250
            var searchDefinition6 = new SearchDefinition<TestEntity>() { Page = 5, RecordsPerPage = 50 }; // 251-300
            var searchResults1 = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition1);
            var searchResults2 = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition2);
            var searchResults3 = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition3);
            var searchResults4 = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition4);
            var searchResults5 = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition5);
            var searchResults6 = new Searcher<TestEntity>(testCollection.AsQueryable()).Search(searchDefinition6);
            var recombinedDataset = new List<TestEntity>();
            recombinedDataset.AddRange(searchResults1.ResultSet);
            recombinedDataset.AddRange(searchResults2.ResultSet);
            recombinedDataset.AddRange(searchResults3.ResultSet);
            recombinedDataset.AddRange(searchResults4.ResultSet);
            recombinedDataset.AddRange(searchResults5.ResultSet);
            recombinedDataset.AddRange(searchResults6.ResultSet);

            // Assert
            Assert.Equal(testCollection.Count, recombinedDataset.Count);
        }
    }
}
