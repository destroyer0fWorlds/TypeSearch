using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TypeSearch.Tests.EfCore.Mocks
{
    class TestEntity
    {
        [Key]
        public int Id { get; set; }

        public string StringProperty { get; set; }

        public bool BoolProperty { get; set; }

        public bool? NullableBoolProperty { get; set; }

        public DateTime DateTimeProperty { get; set; }

        public DateTime? NullableDateTimeProperty { get; set; }

        public byte ByteProperty { get; set; }

        public byte? NullableByteProperty { get; set; }

        public int IntProperty { get; set; }

        public int? NullableIntProperty { get; set; }

        public Guid GuidProperty { get; set; }

        public Guid? NullableGuidProperty { get; set; }
    }
}
