using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Tests.Mocks
{
    class TestChildEntity
    {
        public int ChildId { get; set; }

        public string Title { get; set; }

        public TestChildEntity NChild { get; set; }
    }
}
