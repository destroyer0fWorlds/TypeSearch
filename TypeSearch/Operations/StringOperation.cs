
namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to string types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class StringOperation<T, TResult> : ObjectOperation<T, TResult>, IStringOperation<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public StringOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(propertyName, @operator, filter)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public StringOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(collectionName, propertyName, @operator, filter)
        {

        }

        /// <inheritdoc />
        public FilterCriteria<T> Contains(string value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateContainsCriteria(value));
            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> DoesNotContain(string value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateNotContainsCriteria(value));
            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> EndsWith(string value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateEndsWithCriteria(value));
            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> DoesNotEndWith(string value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateNotEndsWithCriteria(value));
            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> StartsWith(string value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateStartsWithCriteria(value));
            return this.Filter;
        }

        /// <inheritdoc />
        public FilterCriteria<T> DoesNotStartWith(string value)
        {
            this.Filter.Criteria.Add(this.CriteriaFactory.CreateNotStartsWithCriteria(value));
            return this.Filter;
        }
    }
}
