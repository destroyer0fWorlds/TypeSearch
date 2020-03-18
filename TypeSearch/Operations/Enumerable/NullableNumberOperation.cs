
namespace TypeSearch.Operations.Enumerable
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
        /// <param name="collectionName">Collection property name</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="operator">Operator</param>
        /// <param name="where">Parent filter criteria</param>
        public NullableNumberOperation(string collectionName, string propertyName, LogicalOperator @operator, WhereCriteria<T> where) : base(collectionName, propertyName, @operator, where)
        {
            _nullableOperation = new NullableOperation<T, TResult>(collectionName, propertyName, @operator, where);
        }

        /// <inheritdoc />
        public WhereCriteria<T> IsNotNull()
        {
            return _nullableOperation.IsNotNull();
        }

        /// <inheritdoc />
        public WhereCriteria<T> IsNull()
        {
            return _nullableOperation.IsNull();
        }
    }
}
