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

        /// <summary>
        /// Range criterion
        /// </summary>
        public RangeCriterion RangeCriterion { get; set; }

        /// <summary>
        /// Nested criteria
        /// </summary>
        public WhereCriteria<T> CriteriaCollection { get; set; }

        /// <summary>
        /// Condition by which multiple clauses should be evaluated
        /// </summary>
        public LogicalOperator Operator { get; set; }
    }
}
