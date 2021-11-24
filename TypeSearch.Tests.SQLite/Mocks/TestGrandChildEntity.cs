using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TypeSearch.Tests.SQLite.Mocks
{
    class TestGrandChildEntity
    {
        [Key]
        public int GrandChildId { get; set; }

        public int ParentId { get; set; }

        public string Title { get; set; }
    }
}
