
namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to nullable types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class NullableOperation<T, TResult> : ObjectOperation<T, TResult>, INullableOperation<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public NullableOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(propertyName, @operator, filter)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public NullableOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(collectionName, propertyName, @operator, filter)
        {

        }

        /// <inheritdoc />
        public FilterCriteria<T> IsNull()
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateNullCriteria());
            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> IsNotNull()
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateNotNullCriteria());
            return this.Filter;
        }
    }
}
