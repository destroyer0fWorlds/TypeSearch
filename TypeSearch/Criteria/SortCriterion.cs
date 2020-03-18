using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria
{
    /// <summary>
    /// Criterion which describes how a field should be sorted
    /// </summary>
    public class SortCriterion : BaseCriterion
    {
        /// <summary>
        /// Sort direction
        /// </summary>
        public SortDirection SortDirection { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{this.Name} {this.SortDirection}";
        }
    }
}
