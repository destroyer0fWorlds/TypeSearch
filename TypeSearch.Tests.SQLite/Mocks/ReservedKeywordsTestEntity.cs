using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TypeSearch.Tests.SQLite.Mocks
{
    class ReservedKeywordsTestEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Parent { get; set; }
    }
}
