using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TypeSearch.Tests.EfCore.Mocks
{
    class TestParentEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public TestChildEntity Child { get; set; }

        public List<TestChildrenEntity> Children { get; set; }
    }
}
