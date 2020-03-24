
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
        /// Indicates whether this container has a <see cref="SingleCriterion{T}"/>
        /// </summary>
        internal bool HasSingleCriterion => this.SingleCriterion != null;

        /// <summary>
        /// Range criterion
        /// </summary>
        public RangeCriterion RangeCriterion { get; set; }

        /// <summary>
        /// Indicates whether this container has a <see cref="Criteria.RangeCriterion"/>
        /// </summary>
        internal bool HasRangeCriterion => this.RangeCriterion != null;

        /// <summary>
        /// Nested filter
        /// </summary>
        public FilterCriteria<T> NestedFilter { get; set; }

        /// <summary>
        /// Indicates whether this container has nested criteria
        /// </summary>
        internal bool HasNestedCriteria => this.NestedFilter != null && this.NestedFilter.Criteria != null;

        /// <summary>
        /// Condition by which multiple clauses should be evaluated
        /// </summary>
        public LogicalOperator Operator { get; set; }
    }
}
