using TypeSearch.Criteria;

namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to boolean types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class BooleanOperation<T, TResult> : StringOperation<T, TResult>, IBooleanOperation<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public BooleanOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(propertyName, @operator, filter)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public BooleanOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(collectionName, propertyName, @operator, filter)
        {

        }

        /// <inheritdoc />
        public FilterCriteria<T> IsFalse()
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateFalseCriteria());
            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> IsTrue()
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateTrueCriteria());
            return this.Filter;
        }
    }
}
