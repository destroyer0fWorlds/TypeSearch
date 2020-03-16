using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Tests.Mocks
{
    class TestParentEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TestChildEntity Child { get; set; }

        public List<TestChildEntity> Children { get; set; }
    }
}
