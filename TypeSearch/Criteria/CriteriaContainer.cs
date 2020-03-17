using System;
using System.Collections.Generic;
using System.Text;

namespace TypeSearch.Criteria
{
    /// <summary>
    /// Container for holding one or more filter criteria
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CriteriaContainer<T>
        where T : class
    {
        /// <summary>
		/// Single criterion
		/// </summary>
		public SingleCriterion<T> SingleCriterion { get; set; }

        internal bool HasSingleCriterion => this.SingleCriterion != null;

        /// <summary>
        /// Range criterion
        /// </summary>
        public RangeCriterion RangeCriterion { get; set; }

        internal bool HasRangeCriterion => this.RangeCriterion != null;

        /// <summary>
        /// Nested filter
        /// </summary>
        public WhereCriteria<T> NestedFilter { get; set; }

        internal bool HasNestedCriteria => this.NestedFilter != null && this.NestedFilter.Criteria != null;

        /// <summary>
        /// Condition by which multiple clauses should be evaluated
        /// </summary>
        public LogicalOperator Operator { get; set; }
    }
}
