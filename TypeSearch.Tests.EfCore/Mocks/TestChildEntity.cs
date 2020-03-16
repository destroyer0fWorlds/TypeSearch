using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TypeSearch.Tests.EfCore.Mocks
{
    class TestChildEntity
    {
        [Key]
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Title { get; set; }

        public TestGrandChildEntity GrandChild { get; set; }
    }
}
