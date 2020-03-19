
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
        /// <param name="where">Parent filter criteria</param>
        public NullableNumberOperation(string propertyName, LogicalOperator @operator, FilterCriteria<T> where) : base(propertyName, @operator, where)
        {
            _nullableOperation = new NullableOperation<T, TResult>(propertyName, @operator, where);
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
