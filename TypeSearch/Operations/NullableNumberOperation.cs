
namespace TypeSearch.Operations
{
    /// <summary>
    /// Exposes the operations available to nullable number types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class NullableNumberOperation<T, TResult> : NumberOperation<T, TResult>, INullableOperation<T>
        where T : class
    {
        private readonly NullableOperation<T, TResult> _nullableOperation;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableNumberOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public NullableNumberOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(propertyName, @operator, filter)
        {
            _nullableOperation = new NullableOperation<T, TResult>(propertyName, @operator, filter);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableNumberOperation{T, TResult}"/> class
        /// </summary>
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="filter">Parent filter criteria</param>
        public NullableNumberOperation(string collectionName, string propertyName, LogicalOperator @operator, FilterCriteria<T> filter) : base(collectionName, propertyName, @operator, filter)
        {
            _nullableOperation = new NullableOperation<T, TResult>(collectionName, propertyName, @operator, filter);
        }

        /// <inheritdoc />
        public FilterCriteria<T> IsNotNull()
        {
            return _nullableOperation.IsNotNull();
        }

        /// <inheritdoc />
        public FilterCriteria<T> IsNull()
        {
            return _nullableOperation.IsNull();
        }
    }
}
